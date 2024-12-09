//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.CartItem;
using Market.Api.services.foundation.cartitem;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.cartitem
{
    public partial class CartItemServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly CartItemService cartItemService;

        public CartItemServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.cartItemService =
                new CartItemService(storageBroker: this.storageBrokerMock.Object);
        }

        private static CartItem CreateRandomCartitem() =>
            CreateCartItemFiller().Create();

        private static Filler<CartItem> CreateCartItemFiller() => new Filler<CartItem>();
    }
}
