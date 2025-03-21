//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;

namespace Market.Api.services.foundation.product
{
    public partial class ProductService
    {
        private void ValidateProductOnAdd(Products product)
        {
            ValidateProductNotNull(product);

            Validate(
                (Rule: IsInvalid(product.Id), Parameter: nameof(Products.Id)),
                (Rule: IsInvalid(product.Name), Parameter: nameof(Products.Name)),
                (Rule: IsInvalid(product.Price), Parameter: nameof(Products.Price))
                );
        }

        private void ValidateProductIdDelete(Guid productId)
        {
            Validate(
                (Rule: IsInvalid(productId), Parameter: nameof(Products.Id))
            );
        }


        private void ValidateProductNotNull(Products product)
        {
            if (product is null)
            {
                throw new NullProductException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(decimal number) => new
        {
            Condition = number == decimal.MinValue,
            Message = "Price is required"
        };

        private static void Validate(params (dynamic Rule, string Parametr)[] validations)
        {
            var invalidProductExceptions = new InvalidProductException();

            foreach ((dynamic rule, string parametr) in validations)
            {
                if (rule.Condition)
                {
                    invalidProductExceptions.UpsertDataList(
                        key: parametr,
                        value: rule.Message);
                }
            }
            invalidProductExceptions.ThrowIfContainsErrors();
        }
    }
}
