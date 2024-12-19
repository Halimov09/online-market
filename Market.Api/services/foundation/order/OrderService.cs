//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Order;

namespace Market.Api.services.foundation.order
{
    public class OrderService : IOrderService
    {
        private readonly IstorageBroker storageBroker;

        public OrderService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Order> AddOrderAsync(Order order) =>
            await this.storageBroker.InsertOrderAsync(order);
    }
}
