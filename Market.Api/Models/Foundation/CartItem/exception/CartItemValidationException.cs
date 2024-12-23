//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.CartItem.exception
{
    public class CartItemValidationException : Xeption
    {
        public CartItemValidationException(Xeption innerException)
            :base(message: "CartItem error validation occured, fix the error please try again",
                 innerException)
        {}
    }
}
