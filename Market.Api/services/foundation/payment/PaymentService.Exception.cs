//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Xeptions;

namespace Market.Api.services.foundation.payment
{
    public partial class PaymentService
    {
        private delegate ValueTask<Payment> ReturningPaymentExceptions();

        private async ValueTask<Payment> TryCatch(ReturningPaymentExceptions returningPaymentExceptions)
        {
            try
            {
                return await returningPaymentExceptions();
            }
            catch (NullPaymentException nullPaymentException)
            {
                throw CreateAndLogValidationException(nullPaymentException);
            }
        }
        private PaymentValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var paymentValidationException =
                    new PaymentValidationException(xeption);

            this.loggingBroker.LogError(paymentValidationException);

            return paymentValidationException;
        }
    }
}
