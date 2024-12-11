//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;

namespace Market.Api.services.foundation.payment
{
    public interface IpaymentService
    {
        ValueTask<Payment> AddPaymentAsync(Payment payment);
    }
}
