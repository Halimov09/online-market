//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.CartItem.exception
{
    public class NullCartItemException : Xeption
    {
        public NullCartItemException()
            : base(message: "CartItem is null")
        {}
    }
}
