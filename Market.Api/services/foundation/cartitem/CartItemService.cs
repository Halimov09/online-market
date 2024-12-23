//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.CartItem;
using Market.Api.Models.Foundation.CartItem.exception;

namespace Market.Api.services.foundation.cartitem
{
    public class CartItemService : ICartItemService
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

        public async ValueTask<CartItem> AddCartItemAsync(CartItem cartItem)
        {
            try
            {
                if (cartItem is null)
                {
                    throw new NullCartItemException();
                }
                return await this.storageBroker.InsertCartItemAsync(cartItem);
            }
            catch (NullCartItemException nullCartrItemException) 
            {
                var actualCartItemException =
                    new CartItemValidationException(nullCartrItemException);

                this.loggingBroker.LogError(actualCartItemException);

                throw actualCartItemException;
            }
        }
            
    }
}
