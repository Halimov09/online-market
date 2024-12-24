//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Order;
using Market.Api.Models.Foundation.Order.exception;
using Xeptions;

namespace Market.Api.services.foundation.order
{
    public partial class OrderService
    {
        private delegate ValueTask<Order> ReturningOrderExceptions();

        private async ValueTask<Order> TryCatch(ReturningOrderExceptions returningOrderExceptions)
        {
            try
            {
                return await returningOrderExceptions();
            }
            catch (NullOrderException nullOrderException)
            {
                throw CreateAndLogValidationException(nullOrderException);
            }
        }
        private OrderValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var orderValidationException =
                    new OrderValidationException(xeption);

            this.loggingBroker.LogError(orderValidationException);

            return orderValidationException;
        }

    }
}
