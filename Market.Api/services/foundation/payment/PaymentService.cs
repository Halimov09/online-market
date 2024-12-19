//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Xeptions;

namespace Market.Api.services.foundation.payment
{
    public class PaymentService : IpaymentService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public PaymentService(
            IstorageBroker storageBroker, 
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Payment> AddPaymentAsync(Payment payment)
        {
            try
            {
                if (payment is null)
                {
                    throw new NullPaymentException();
                }
                return await this.storageBroker.InsertPaymentAsync(payment);
            }
            catch (NullPaymentException nullPaymentException) 
            {
                var paymentNullException =
                    new PaymentValidationException(nullPaymentException);

                this.loggingBroker.LogError(paymentNullException);

                throw paymentNullException;
            }

        }
    }
}
