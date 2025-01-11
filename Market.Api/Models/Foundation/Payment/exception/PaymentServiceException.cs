//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class PaymentServiceException : Xeption
    {
        public PaymentServiceException(Xeption innerExcetion)
            : base(message: "Payment service error occured,contact support",
                 innerExcetion)
        { }
    }
}
