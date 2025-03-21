//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;

namespace Market.Api.Models.Foundation.Categorys
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid productId { get; set; }
        public Products Product { get; set; }
    }
}
