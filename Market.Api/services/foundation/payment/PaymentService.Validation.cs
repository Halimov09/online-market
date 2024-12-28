//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;

namespace Market.Api.services.foundation.payment
{
    public partial class PaymentService
    {
        private void ValidatePaymentOnAdd(Payment payment)
        {
            ValidatePaymentNotNull(payment);

            Validate(
                (Rule: IsInvalid(payment.Id), Parameter: nameof(Payment.Id)),
                (Rule: IsInvalid(payment.paymentMethod), Parameter: nameof(Payment.paymentMethod))
                );
        }

        private void ValidatePaymentNotNull(Payment payment)
        {
            if (payment is null)
            {
                throw new NullPaymentException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(decimal amount) => new
        {
            Condition = amount == decimal.MaxValue,
            Message = "Amount is required"
        };

        private static dynamic IsInvalid(PaymentMethod paymentMethod) => new
        {
            Condition = Enum.IsDefined(paymentMethod) is false,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidPaymentException = new InvalidPaymentException();

            foreach ((dynamic rule, string parametr) in validations)
            {
                if (rule.Condition)
                {
                    invalidPaymentException.UpsertDataList(
                        key: parametr,
                        value: rule.Message);
                }
            }
            invalidPaymentException.ThrowIfContainsErrors();
        }
    }
}
