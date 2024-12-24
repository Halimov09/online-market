//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Order;
using Market.Api.Models.Foundation.Order.exception;

namespace Market.Api.services.foundation.order
{
    public partial class OrderService
    {
        private void ValidateOrderNotNull(Order order)
        {
            if (order is null)
            {
                throw new NullOrderException();
            }
        }
    }
}
