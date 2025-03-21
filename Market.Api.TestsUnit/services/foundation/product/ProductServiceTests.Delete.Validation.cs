//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
using Moq;
using Xunit.Abstractions;

namespace Market.Api.TestsUnit.services.foundation.product
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnRemoveIfIdIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidProductId = Guid.Empty;

            var invalidProductException =
                new InvalidProductException();

            invalidProductException.AddData(
                key: nameof(Products.Id),
                values: "Id is required");

            var expectedValidationException =
                new ProductValidationException(invalidProductException);

            //when
            ValueTask<Products> removeProductById =
                this.productService.DeleteProductByIdAsync(invalidProductId);

            ProductValidationException actualCompanyValidationExecption =
                await Assert.ThrowsAsync<ProductValidationException>(
                    removeProductById.AsTask);

            //then
            actualCompanyValidationExecption.Should().BeEquivalentTo(expectedValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteProductAsync(It.IsAny<Products>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowNotFoundExceptionOnRemoveProductByIdIsNotFoundAndLogItAsync()
        {
            // given
            Guid inputProductId = Guid.NewGuid();
            Products noProduct = null;

            var notFoundProductException =
                new NotFoundProductException(inputProductId);

            var expectedProductValidationException =
                new ProductValidationException(notFoundProductException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectProductByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(noProduct);

            // when
            ValueTask<Products> removeProductById =
                this.productService.DeleteProductByIdAsync(inputProductId);

            var actualProductValidationException =
                await Assert.ThrowsAsync<ProductValidationException>(
                    removeProductById.AsTask);

            // then
            actualProductValidationException.Should().BeEquivalentTo(expectedProductValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectProductByIdAsync(It.IsAny<Guid>()), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedProductValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
