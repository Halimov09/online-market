//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.CartItem;

namespace Market.Api.services.foundation.cartitem
{
    public class CartItemService : ICartItemService
    {
        private readonly IstorageBroker storageBroker;

        public CartItemService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<CartItem> AddCartItemAsync(CartItem cartItem) =>
            await this.storageBroker.InsertCartItemAsync(cartItem);
    }
}
