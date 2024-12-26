//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Cart;
using Market.Api.Models.Foundation.Cart.exception;
using Xeptions;

namespace Market.Api.services.foundation.cart
{
    public partial class CartService
    {
        private delegate ValueTask<Cart> ReturningCartExceptions();

        private async ValueTask<Cart> TryCatch(ReturningCartExceptions returningCartExceptions)
        {
            try
            {
                return await returningCartExceptions();
            }
            catch (NullCartException nullCartException)
            {
                throw CreateAndLogValidationException(nullCartException);
            }
        }
        private CartValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var cartValidationException =
                    new CartValidationException(xeption);

            this.loggingBroker.LogError(cartValidationException);

            return cartValidationException;
        }
    }
}
