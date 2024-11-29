//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.OrderItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet <OrderItem> OrderItems { get; set; }

        public async ValueTask<OrderItem> InsertOrderItemAsync(OrderItem item)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<OrderItem> orderItemEntityEntry = 
                await broker.OrderItems.AddAsync(item);

            await broker.SaveChangesAsync();

            return orderItemEntityEntry.Entity;
        }
    }
}
