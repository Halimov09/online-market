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
        private void ValidateOrderOnAdd(Order order)
        {
            ValidateOrderNotNull(order);

            Validate(
                (Rule: IsInvalid(order.Id), Parameter: nameof(Order.Id)),
                (Rule: IsInvalid(order.TotalPrice), Parameter: nameof(Order.TotalPrice))
                );
        }

        private void ValidateOrderNotNull(Order order)
        {
            if (order is null)
            {
                throw new NullOrderException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(decimal totalPrice) => new
        {
            Condition = totalPrice == decimal.MaxValue,
            Message = "totalPrice is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidCategoryException = new InvalidOrderExceptoion();
            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidCategoryException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }
            invalidCategoryException.ThrowIfContainsErrors();
        }
    }
}
