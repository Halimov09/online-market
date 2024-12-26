//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.CartItem.exception;
using Market.Api.Models.Foundation.CartItem;
using Xeptions;

namespace Market.Api.services.foundation.cartitem
{
    public partial class CartItemService
    {
        private delegate ValueTask<CartItem> ReturningCartItemExceptions();

        private async ValueTask<CartItem> TryCatch(ReturningCartItemExceptions returningCartItemExceptions)
        {
            try
            {
                return await returningCartItemExceptions();
            }
            catch (NullCartItemException nullCartItemException)
            {
                throw CreateAndLogValidationException(nullCartItemException);
            }
        }
        private CartItemValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var cartItemValidationException =
                    new CartItemValidationException(xeption);

            this.loggingBroker.LogError(cartItemValidationException);

            return cartItemValidationException;
        }
    }
}
