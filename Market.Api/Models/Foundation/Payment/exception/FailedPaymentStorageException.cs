//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class FailedPaymentStorageException : Xeption
    {
        public FailedPaymentStorageException(Exception exception)
            :base(message: "Failed payment error occured, contact support",
                 exception) 
        {}
    }
}
