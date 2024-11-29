//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.OrderItem;

namespace Market.Api.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<OrderItem> InsertOrderItemAsync(OrderItem item);
    }
}
