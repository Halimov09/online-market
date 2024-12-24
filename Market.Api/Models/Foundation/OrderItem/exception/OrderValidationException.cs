//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.OrderItem.exception
{
    public class OrderValidationException : Xeption
    {
        public OrderValidationException(Xeption innerException)
            : base(message: "Order validation error occured, fix the errors and try again",
                 innerException)
        { }
    }
}
