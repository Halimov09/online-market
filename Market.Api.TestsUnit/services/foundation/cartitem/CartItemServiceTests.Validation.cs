//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem;
using Market.Api.Models.Foundation.CartItem.exception;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.cartitem
{
    public partial class CartItemServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationCartItemOnAddIfAndLogitAsync()
        {
            //given
            CartItem nullCartItem = null;
            var nullCartItemException = new NullCartItemException();

            var expectedCartItemException =
                new CartItemValidationException(nullCartItemException);

            //when
            ValueTask<CartItem> addCarItemTask =
                this.cartItemService.AddCartItemAsync(nullCartItem);

            //then
            await Assert.ThrowsAsync<CartItemValidationException> (() =>
            addCarItemTask.AsTask ());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedCartItemException))), Times.Once());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertCartItemAsync(It.IsAny<CartItem>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
