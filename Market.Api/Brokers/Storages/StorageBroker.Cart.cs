//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Cart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Cart> carts { get; set; }

        public async ValueTask<Cart> InsertCartAsync(Cart cart)
        {
            using var broker = new StorageBroker(this.configuration);
        
            EntityEntry<Cart> cartEntityEntry = 
                await broker.carts.AddAsync(cart);

            await broker.SaveChangesAsync();

            return cartEntityEntry.Entity;
        }
    }
}
