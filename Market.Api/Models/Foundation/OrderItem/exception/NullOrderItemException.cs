//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.OrderItem.exception
{
    public class NullOrderItemException : Xeption
    {
        public NullOrderItemException()
            : base(message: "Order is null")
        {

        }
    }
}
