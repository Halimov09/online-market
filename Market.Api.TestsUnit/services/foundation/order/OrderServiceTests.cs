//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Order;
using Market.Api.services.foundation.order;
using Moq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.order
{
    public partial class OrderServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly OrderService orderService;

        public OrderServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.orderService =
                new OrderService(
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Order CreateRandomOrder() =>
            CreateOrderFiller(date: GetRandomDateTimeOffSet()).Create();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedOrderException)
        {
            return actualOrderException =>
                actualOrderException.Message == expectedOrderException.Message &&
                actualOrderException.InnerException.Message == 
                expectedOrderException.InnerException.Message
                && (actualOrderException.InnerException as Xeption)
                .DataEquals(expectedOrderException.InnerException.Data);
        }

        private static DateTimeOffset GetRandomDateTimeOffSet() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Order> CreateOrderFiller(DateTimeOffset date)
        {
            var filler = new Filler<Order>();

            filler.Setup().OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
