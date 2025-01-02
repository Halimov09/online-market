//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class ProductDependencyException : Xeption
    {
        public ProductDependencyException(Xeption innerException)
            :base("Product depency error occured, contact support", 
                 innerException)
        {}
    }
}
