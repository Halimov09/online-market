//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;
using Market.Api.services.foundation.cartitem;

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

            //when

            //then
        }
    }
}
