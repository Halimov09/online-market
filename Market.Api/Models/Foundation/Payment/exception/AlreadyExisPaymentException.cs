//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class AlreadyExisPaymentException : Xeption
    {
        public AlreadyExisPaymentException(Exception innerException)
            : base(message: "Payment already exis error", innerException)
        { }
    }
}
