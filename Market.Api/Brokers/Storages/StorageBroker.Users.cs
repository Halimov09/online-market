//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Users> Users { get; set; }
        public async ValueTask<Users> InsertUsersAsync(Users user) 
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Users> userEntityEntry = 
                await broker.Users.AddAsync(user);

            await broker.SaveChangesAsync();

            return userEntityEntry.Entity;
        }
    }
}
