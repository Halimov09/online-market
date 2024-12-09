//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Cart;

namespace Market.Api.services.foundation.cart
{
    public class CartService : ICartService
    {
        private readonly IstorageBroker storageBroker;

        public CartService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Cart> AddCartAsync(Cart cart) =>
            await this.storageBroker.InsertCartAsync(cart);
        
    }
}
