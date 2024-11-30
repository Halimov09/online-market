//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<CartItem> cartItems { get; set; }

        public async ValueTask<CartItem> InsertCartItemAsync(CartItem cartItems)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<CartItem> cartItemEntityEntry =
                await broker.cartItems.AddAsync(cartItems);

            await broker.SaveChangesAsync();

            return cartItemEntityEntry.Entity;
        }
    }
}
