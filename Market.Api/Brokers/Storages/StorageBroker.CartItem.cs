//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;
using Microsoft.EntityFrameworkCore;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<CartItem> CartItems { get; set; }
    }
}
