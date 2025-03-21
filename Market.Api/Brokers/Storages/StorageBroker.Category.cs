//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Categorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Category> categories { get; set; }

        public async ValueTask<Category> InsertCategoryAsync(Category category)
        {
            using var broker = new StorageBroker(this.configuration);   

            EntityEntry<Category> categoryEntityEntry = 
                await broker.categories.AddAsync(category);

            await broker.SaveChangesAsync();

            return categoryEntityEntry.Entity;
        }
    }
}
