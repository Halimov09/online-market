//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class NullPaymentException : Xeption
    {
        public NullPaymentException()
            :base(message: "Payment is null")
        {}
    }
}
