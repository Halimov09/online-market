//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================


using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
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
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowExceptionOnAddIfProductIsInvalidAndLogitAsync(
            string invalidtext)
        {
            //given
            var productInvalid = new Product
            {
                Name = invalidtext,
            };

            var invalidProductException = new InvalidProductException();

            invalidProductException.AddData(
                key: nameof(Product.Id),
                values: "Id is required");

            invalidProductException.AddData(
                key: nameof(Product.CategoryId),
                values: "CategoryId is required");

            invalidProductException.AddData(
                key: nameof(Product.Name),
                values: "Text is required");

            invalidProductException.AddData(
                key: nameof(Product.Description),
                values: "Text is required");

            invalidProductException.AddData(
                key: nameof(Product.Price),
                values: "Price is required");

            var expectedProductException =
                new ProductValidationException(invalidProductException);

            //when
            ValueTask<Product> addProductTask =
                this.productService.AddProductAsync(productInvalid);

            //then
            await Assert.ThrowsAsync<ProductValidationException>(() =>
            addProductTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedProductException))),
            Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertProductAsync(It.IsAny<Product>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
