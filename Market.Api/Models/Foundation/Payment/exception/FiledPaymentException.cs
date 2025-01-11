//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Payment.exception
{
    public class FiledPaymentException : Xeption
    {
        public FiledPaymentException(Exception innerException)
            : base(message: "failed Payment exception error occured", innerException)
        { }
    }
}
