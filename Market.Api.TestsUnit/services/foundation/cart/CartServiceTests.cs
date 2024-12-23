//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Cart;
using Market.Api.Models.Foundation.Cart.exception;
using Market.Api.services.foundation.cart;
using Moq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.cart
{
    public partial class CartServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;    
        private readonly CartService cartService;

        public CartServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.cartService = 
                new CartService(
                storageBroker: this.storageBrokerMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Cart CreateRandomCart() =>
            CreateCartFiller(date: GetRandomDateTimeOffSet()).Create();

        public Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedCArtException)
        {
            return actualCArtException => 
            actualCArtException.Message == expectedCArtException.Message &&
            actualCArtException.InnerException.Message ==
            expectedCArtException.InnerException.Message 
            && (actualCArtException.InnerException as Xeption)
            .DataEquals(expectedCArtException.Data);
        }

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
