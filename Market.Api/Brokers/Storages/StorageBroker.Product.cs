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
    }
}
