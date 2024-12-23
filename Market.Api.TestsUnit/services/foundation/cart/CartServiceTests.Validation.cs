//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Cart;
using Market.Api.Models.Foundation.Cart.exception;
using Moq;
using System.Linq.Expressions;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.cart
{
    public partial class CartServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationCartOnAddIfAndLogitAsync()
        {
            //given
            Cart cartNull = null;
            var cartNullException = new NullCartException();

            var expetedCartException = 
                new CartValidationException(cartNullException);

            //when
            ValueTask<Cart> addCartTask =
                this.cartService.AddCartAsync(cartNull);

            //then
            await Assert.ThrowsAsync<CartValidationException>(() =>
            addCartTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
             broker.LogError(It.Is(SameExceptionAs(expetedCartException))), Times.Once());

            this.storageBrokerMock.Verify(broker =>
             broker.InsertCartAsync(It.IsAny<Cart>()), Times.Never);
            
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        
    }
}
