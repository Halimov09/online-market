//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Order.exception
{
    public class InvalidOrderExceptoion : Xeption
    {
        public InvalidOrderExceptoion()
            :base(message: "Order is invalid")
        {}
    }
}
