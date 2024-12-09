//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Cart;
using Market.Api.services.foundation.cart;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.cart
{
    public partial class CartServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly CartService cartService;

        public CartServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.cartService = 
                new CartService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Cart CreateRandomCart() =>
            CreateCartFiller(date: GetRandomDateTimeOffSet()).Create();

        private static DateTimeOffset GetRandomDateTimeOffSet() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Cart> CreateCartFiller(DateTimeOffset date)
        {
            var filler = new Filler<Cart>();

            filler.Setup().OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
