//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Cart;
using Market.Api.Models.Foundation.Cart.exception;

namespace Market.Api.services.foundation.cart
{
    public class CartService : ICartService
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

        public async ValueTask<Cart> AddCartAsync(Cart cart)
        {
            try 
            {
                if (cart is null)
                {
                    throw new NullCartException();
                }
                return await this.storageBroker.InsertCartAsync(cart);
            }
            catch (NullCartException expectedCartException) 
            {
                var actualCartException = 
                    new CartValidationException(expectedCartException);

                this.loggingBroker.LogError(actualCartException);

                throw actualCartException;
            }
        }
        
    }
}
