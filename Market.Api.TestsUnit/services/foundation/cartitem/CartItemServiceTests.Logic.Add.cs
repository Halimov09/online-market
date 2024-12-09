//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Market.Api.Models.Foundation.CartItem;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.cartitem
{
    public partial class CartItemServiceTests
    {
        [Fact]
        public async Task ShouldAddCartItemAsync()
        {
            //given
            CartItem createRandomCartitem = CreateRandomCartitem();
            CartItem inputCartItem = createRandomCartitem;
            CartItem returningCartitem = inputCartItem;
            CartItem expectedCartitem = returningCartitem;

            this.storageBrokerMock.Setup(broker =>
            broker.InsertCartItemAsync(inputCartItem)).ReturnsAsync(returningCartitem);

            //when
            CartItem actualCartitem = await this.cartItemService.AddCartItemAsync(inputCartItem);

            //then
            actualCartitem.Should().BeEquivalentTo(expectedCartitem);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertCartItemAsync(inputCartItem), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
