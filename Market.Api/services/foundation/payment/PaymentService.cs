//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Payment;

namespace Market.Api.services.foundation.payment
{
    public partial class PaymentService : IpaymentService
    {
        private readonly IstorageBroker storageBroker;

    }
}
