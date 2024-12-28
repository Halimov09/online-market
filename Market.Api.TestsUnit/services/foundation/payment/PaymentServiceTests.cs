//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Payment;
using Market.Api.services.foundation.payment;
using Moq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.payment
{
    public partial class PaymentServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly PaymentService paymentService;

        public PaymentServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.paymentService =
                new PaymentService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Payment CreateRandomPayment() =>
            CreatePaymentFiller().Create();

        private static int GetRandomNumber() =>
           new IntRange(min: 2, max: 9).GetValue();

        private static T GetInvalidEnum<T>()
        {
            int randomNumber = GetRandomNumber();

            while (Enum.IsDefined(typeof(T), randomNumber) is true)
            {
                randomNumber = GetRandomNumber();
            }

            return (T)(object)randomNumber;
        }

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
            actualException.Message == expectedException.Message
            && actualException.InnerException.Message ==
            expectedException.InnerException.Message;
        }

        private static Filler<Payment> CreatePaymentFiller() => new Filler<Payment>();
    }
}
