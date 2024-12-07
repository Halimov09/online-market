//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Order;

namespace Market.Api.services.foundation.order
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(Order order);
    }
}
