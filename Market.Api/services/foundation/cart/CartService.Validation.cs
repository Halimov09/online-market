//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Cart;
using Market.Api.Models.Foundation.Cart.exception;

namespace Market.Api.services.foundation.cart
{
    public partial class CartService
    {
        private void ValidateCartNotNull(Cart cart)
        {
            if (cart is null)
            {
                throw new NullCartException();
            }
        }
    }
}
