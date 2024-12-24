//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;
using Market.Api.Models.Foundation.CartItem.exception;

namespace Market.Api.services.foundation.cartitem
{
    public partial class CartItemService
    {
        private void ValidateCartItemNotNull(CartItem cartItem)
        {
            if (cartItem is null)
            {
                throw new NullCartItemException();
            }
        }
    }
}
