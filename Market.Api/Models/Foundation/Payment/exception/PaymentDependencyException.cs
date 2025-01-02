//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class PaymentDependencyException : Xeption
    {
        public PaymentDependencyException(Xeption xeption)
            :base("Payment dependency error occured, contact support", 
                 xeption)
        {}
    }
}
