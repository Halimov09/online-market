//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class InvalidPaymentException : Xeption
    {
        public InvalidPaymentException()
            : base(message: "Payment is invalid")
        { }
    }
}
