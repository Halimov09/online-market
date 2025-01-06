//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class ProductServiceException : Xeption
    {
        public ProductServiceException(Xeption innerException)
            : base(message: "User service error occured,contact support",
                 innerException)
        { }
    }
}
