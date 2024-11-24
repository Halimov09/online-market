//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Cart;
using Microsoft.EntityFrameworkCore;

namespace Market.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Cart> carts { get; set; }
    }
}
