//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Payment> Payment { get; set; }

        public async ValueTask<Payment> InsertPaymentAsync(Payment payment)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<Payment> productEntityentry = 
                await broker.Payment.AddAsync(payment);

            await broker.SaveChangesAsync();

            return productEntityentry.Entity;
        }
    }
}
