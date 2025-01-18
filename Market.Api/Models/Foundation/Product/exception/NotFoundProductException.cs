//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class NotFoundProductException : Xeption
    {
        public NotFoundProductException(Guid productId)
            :base(message: $"Couldn't find client with id {productId}.")
        {}
    }
}
