//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
using Market.Api.Models.Foundation.Users;
using System.Data;
using System.Reflection.Metadata;

namespace Market.Api.services.foundation.product
{
    public partial class ProductService
    {
        private void ValidateProductOnAdd(Product product)
        {
            ValidateProductNotNull(product);

            Validate(
                (Rule: IsInvalid(product.Id), Parameter: nameof(Product.Id)),
                (Rule: IsInvalid(product.Name), Parameter: nameof(Product.Name)),
                (Rule: IsInvalid(product.Price), Parameter: nameof(Product.Price))
                );
        }

        private void ValidateProductNotNull(Product product)
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
