//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Order;
using Market.Api.services.foundation.order;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.order
{
    public partial class OrderServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly OrderService orderService;

        public OrderServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.orderService =
                new OrderService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Order CreateRandomOrder() =>
            CreateOrderFiller(date: GetRandomDateTimeOffSet()).Create();

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
