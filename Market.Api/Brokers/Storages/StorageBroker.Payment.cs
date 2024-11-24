//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Microsoft.EntityFrameworkCore;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Payment> Payment { get; set; }
    }
}
