//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class PaymentValidationException : Xeption
    {
        public PaymentValidationException(Xeption innerPaymentExeption)
            :base(message: "Payment validation error occured, fix the error please try again",
                 innerPaymentExeption)
        {}
    }
}
