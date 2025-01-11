//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class PaymentDependencyValidationExcepton : Xeption
    {
        public PaymentDependencyValidationExcepton(Xeption innerException)
            : base(message: "Payment dependencyvalidaion error occured, fix the errors and tryagain",
                 innerException)
        { }
    }
}
