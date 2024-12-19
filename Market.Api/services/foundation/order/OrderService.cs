//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Order;
using Market.Api.Models.Foundation.Order.exception;

namespace Market.Api.services.foundation.order
{
    public class OrderService : IOrderService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public OrderService(
            IstorageBroker storageBroker, 
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Order> AddOrderAsync(Order order)
        {
            try 
            {
                if (order is null)
                {
                    throw new NullOrderException();
                }
                return await this.storageBroker.InsertOrderAsync(order);
            }
            catch (NullOrderException nullOrderException) 
            {
                var actualOrderException =
                    new OrderValidationException(nullOrderException);

                this.loggingBroker.LogError(actualOrderException);

                throw actualOrderException;
            }
        }
    }
}
