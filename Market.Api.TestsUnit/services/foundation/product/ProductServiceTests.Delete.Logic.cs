//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Market.Api.Models.Foundation.Product;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.product
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldDeleteProductByIdAsync()
        {
            // given
            Guid randomProductId = Guid.NewGuid();
            Guid inputProductId = randomProductId;
            Product storageProduct = CreateRandomProduct();
            storageProduct.Id = inputProductId;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectProductByIdAsync(inputProductId))
                    .ReturnsAsync(storageProduct);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteProductAsync(storageProduct))
                    .ReturnsAsync(storageProduct);

            // when
            Product actualProduct =
                await this.productService.DeleteProductByIdAsync(inputProductId);

            // then
            actualProduct.Should().BeEquivalentTo(storageProduct);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectProductByIdAsync(inputProductId), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteProductAsync(storageProduct), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
