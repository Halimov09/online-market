//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class FailedProductStorageException : Xeption
    {
        public FailedProductStorageException(Exception innerException)
            : base("Failed product storage error occured, contact support",
                 innerException)
        { }
    }
}
