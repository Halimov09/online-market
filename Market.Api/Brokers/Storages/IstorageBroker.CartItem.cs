//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;

namespace Market.Api.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<CartItem> InsertCartItemAsync(CartItem cartItems);
    }
}
