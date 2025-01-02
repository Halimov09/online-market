//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
using Microsoft.Data.SqlClient;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.product
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionProductOnAddIfLogItAsync()
        {
            //given
            Product someProduct = CreateRandomProduct();
            SqlException sqlException = GetSqlError();
            var failedProductException = new FailedProductException(sqlException);

            var expectedProductException =
                new ProductDependencyException(failedProductException);

            this.storageBrokerMock.Setup(broker =>
            broker.InsertProductAsync(someProduct))
                .ThrowsAsync(sqlException);

            //when
            ValueTask<Product> addProductTask =
                this.productService.AddProductAsync(someProduct);

            //then
            await Assert.ThrowsAsync<ProductDependencyException> (() =>
            addProductTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertProductAsync(someProduct), Times.Once());

            this.loggingBrokerMock.Verify(broker => 
            broker.LogCritical(It.Is(SameExceptionAs(expectedProductException))), 
            Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
