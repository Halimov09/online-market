//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class ProductValidationException : Xeption
    {
        public ProductValidationException(Xeption innerException)
            :base(message: "Product validation error occured, fix the errors and try again",
                 innerException)
        {}
    }
}
