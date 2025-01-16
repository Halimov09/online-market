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
        public async Task ShouldThrowCriticalDependencyExceptionOnDeleteIfLogItAsync()
        {
            // given
            Guid guid = Guid.NewGuid();
            SqlException sqlException = GetSqlError();

            var failedProductException = 
                new FailedProductStorageException(sqlException);

            var expectedProductException =
                new ProductDependencyException(failedProductException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectProductByIdAsync(guid))
                .Throws(sqlException);

            // when
            ValueTask<Product> deleteProductTask =
                this.productService.DeleteProductByIdAsync(guid);

            // then
            await Assert.ThrowsAsync<ProductDependencyException>(() =>
                deleteProductTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteProductAsync(), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedProductException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

    }
}
