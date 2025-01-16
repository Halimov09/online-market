//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class ProductNotFoundException : Xeption
    {
        public ProductNotFoundException()
            :base(message: "Product not Found")
        {}
    }
}
