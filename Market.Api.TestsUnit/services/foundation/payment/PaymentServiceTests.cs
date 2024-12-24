//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Payment;
using Market.Api.services.foundation.payment;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.payment
{
    public partial class PaymentServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly PaymentService paymentService;

        public PaymentServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.paymentService =
                new PaymentService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Payment CreateRandomPayment() =>
            CreatePaymentFiller().Create();

        private static Filler<Payment> CreatePaymentFiller() => new Filler<Payment>();
    }
}
