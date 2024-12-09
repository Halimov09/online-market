//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;

namespace Market.Api.services.foundation.cartitem
{
    public interface ICartItemService
    {
        ValueTask<CartItem> AddCartItemAsync(CartItem cartItem);
    }
}
