//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Order> orders {  get; set; }

        public async ValueTask<Order> InsertOrderAsync(Order order)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Order> orderEntityEntry = 
                await broker.orders.AddAsync(order);

            await broker.SaveChangesAsync();

            return orderEntityEntry.Entity;
        }
    }
}
