//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.OrderItem.exception
{
    public class InvalidOrderItemException : Xeption
    {
        public InvalidOrderItemException()
            :base(message: "Order is invalid")
        {}
    }
}
