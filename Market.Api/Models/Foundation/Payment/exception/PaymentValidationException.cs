//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class PaymentValidationException : Xeption
    {
        public PaymentValidationException(Xeption innerException)
            : base(message: "Product validation error occured, fix the errors and try again",
                 innerException)
        { }
    }
}
