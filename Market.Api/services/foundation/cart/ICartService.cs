//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Cart;

namespace Market.Api.services.foundation.cart
{
    public interface ICartService
    {
        ValueTask<Cart> AddCartAsync(Cart cart);
    }
}
