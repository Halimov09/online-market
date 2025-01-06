//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class ProductDependencyValidationException : Xeption
    {
        public ProductDependencyValidationException(Xeption innerException) 
            :base(message: "Product dependencyvalidaion error occured, fix the errors and tryagain", 
                 innerException)
        { }
    }
}
