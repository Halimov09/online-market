//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class AlreadyExisProductException : Xeption
    {
        public  AlreadyExisProductException(Exception innerException)
            : base(message: "Product exis error", innerException)
        { }
    }
}
