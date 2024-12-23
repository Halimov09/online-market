//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Cart.exception
{
    public class CartValidationException : Xeption
    {
        public CartValidationException(Xeption innerExeption)
            :base(message: "Cart Validation error occured, fix tje error please try again",
                 innerExeption)
        {}
    }
}
