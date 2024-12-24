//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Cart;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Market.Api.services.foundation.cart
{
    public partial class CartService : ICartService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public CartService(
            IstorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Cart> AddCartAsync(Cart cart) =>
        TryCatch(async () =>
        {
            ValidateCartNotNull(cart);
            return await this.storageBroker.InsertCartAsync(cart);
        });
    }
}
