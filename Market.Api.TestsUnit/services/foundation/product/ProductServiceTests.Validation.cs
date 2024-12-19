//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================


using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
using Market.Api.Models.Foundation.Users;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.product
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldThrowExceptionOnAddIfProductIsNullAndLogitAsync()
        {
            //given
            Product nullProduct = null;
            var nullProductException = new NullProductException();

            var expectedProductException =
                new ProductValidationException(nullProductException);

            //when
            ValueTask<Product> AddProductTask =
                this.productService.AddProductAsync(nullProduct);

            //then
            await Assert.ThrowsAsync<ProductValidationException>(() =>
            AddProductTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedProductException))),
            Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertProductAsync(It.IsAny<Product>()),
            Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
