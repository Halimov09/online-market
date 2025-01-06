//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Force.DeepCloner;
using Market.Api.Models.Foundation.Product;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.product
{
    public partial class ProductServiceTests
    {
        [Fact]
        public async Task ShouldAddProductAsync()
        {
            //given
            Product randomProduct = CreateRandomProduct();
            Product inputProduct = randomProduct;
            Product returningProduct = inputProduct;
            Product expectedProduct = returningProduct.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertProductAsync(inputProduct)).ReturnsAsync(returningProduct);

            //when 
            Product actualProduct =
                await this.productService.AddProductAsync(inputProduct);

            //then
            actualProduct.Should().BeEquivalentTo(expectedProduct);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertProductAsync(inputProduct), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
