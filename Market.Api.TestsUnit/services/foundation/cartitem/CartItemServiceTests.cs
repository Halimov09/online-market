//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.CartItem;
using Market.Api.services.foundation.cartitem;
using Moq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.cartitem
{
    public partial class CartItemServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly CartItemService cartItemService;

        public CartItemServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.cartItemService =
                new CartItemService(
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }

        private static CartItem CreateRandomCartitem() =>
            CreateCartItemFiller().Create();

        public Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedCarItemException)
        {
            return actualCartItemExcption =>
                actualCartItemExcption.Message == expectedCarItemException.Message &&
                actualCartItemExcption.InnerException.Message == 
                expectedCarItemException.InnerException.Message
                && (actualCartItemExcption.InnerException as Xeption)
                .DataEquals(expectedCarItemException.Data);
                
        }

        private static Filler<CartItem> CreateCartItemFiller() => new Filler<CartItem>();
    }
}
