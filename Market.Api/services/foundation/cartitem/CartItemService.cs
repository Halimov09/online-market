//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.CartItem;

namespace Market.Api.services.foundation.cartitem
{
    public partial class CartItemService : ICartItemService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public CartItemService(
            IstorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<CartItem> AddCartItemAsync(CartItem cartItem) =>
        TryCatch(async () =>
        {
            ValidateCartItemNotNull(cartItem);
            return await this.storageBroker.InsertCartItemAsync(cartItem);
        });

    }
}
