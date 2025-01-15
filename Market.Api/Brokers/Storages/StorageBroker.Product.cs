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
        public DbSet<Product> products { get; set; }

        public async ValueTask<Product> InsertProductAsync(Product product)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Product> productEntityEntry =
                await broker.products.AddAsync(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }

        public async ValueTask<Product> SelectProductByIdAsync(Guid productId)
        {
            using var broker = new StorageBroker(this.configuration);

            return await broker.products.FindAsync(productId);
        }

        public async ValueTask<Product> DeleteProductAsync(Product product)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Product> productEntityEntry =
                broker.products.Remove(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }

    }
}
