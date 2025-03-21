//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Products> products { get; set; }

        public async ValueTask<Products> InsertProductAsync(Products product)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Products> productEntityEntry =
                await broker.products.AddAsync(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }

        public async ValueTask<Products> SelectProductByIdAsync(Guid productId)
        {
            using var broker = new StorageBroker(this.configuration);

            return await broker.products.FindAsync(productId);
        }

        public async ValueTask<Products> DeleteProductAsync(Products product)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Products> productEntityEntry =
                broker.products.Remove(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }

    }
}
