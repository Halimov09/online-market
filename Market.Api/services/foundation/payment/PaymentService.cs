//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Payment;

namespace Market.Api.services.foundation.payment
{
    public class PaymentService : IpaymentService
    {
        private readonly IstorageBroker storageBroker;

        public PaymentService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Payment> AddPaymentAsync(Payment payment)=>
            await this.storageBroker.InsertPaymentAsync(payment);
    }
}
