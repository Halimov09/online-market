//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Review;
using Market.Api.Models.Foundation.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Review> reviews { get; set; }

        public async ValueTask<Review> InsertReviewAsync (Review review)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Review> reviewEntityEntry =
                await broker.reviews.AddAsync(review);

            await broker.SaveChangesAsync();

            return reviewEntityEntry.Entity;
        }
    }
}
