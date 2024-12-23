//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Cart.exception
{
    public class NullCartException : Xeption
    {
        public NullCartException()
            :base(message: "Cart is null")
        {}
    }
}
