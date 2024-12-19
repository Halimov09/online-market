//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Order.exception
{
    public class OrderValidationException : Xeption
    {
        public OrderValidationException(Xeption innerOrderException)
            :base(message: "Order validation error occured, fix the error please try again", 
                 innerOrderException)
        {}
    }
}
