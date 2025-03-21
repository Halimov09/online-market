//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================



using Market.Api.Models.Foundation.Categorys;

namespace Market.Api.Models.Foundation.Product
{
    public class Products
    {
        //About product
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
