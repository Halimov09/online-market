//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class FailedProductException : Xeption
    {
        public FailedProductException(Exception innerException)
            :base(message: "Failed product storage error occured, contact support", 
                 innerException)
        {}
    }
}
