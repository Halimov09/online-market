//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Category;
using Market.Api.Models.Foundation.Category.exception;

namespace Market.Api.services.foundation.category
{
    public partial class CategoryService
    {
        private void ValidatePaymentOnAdd(Category category)
        {
            ValidateCategoryNotNull(category);

            Validate(
                (Rule: IsInvalid(category.Id), Parameter: nameof(Category.Id))
                );
        }

        private void ValidateCategoryNotNull(Category category)
        {
            if (category is null)
            {
                throw new NullCategoryException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidCategoryException = new InvalidCategoryException();

            foreach ((dynamic rule, string parametr) in validations)
            {
                if (rule.Condition)
                {
                    invalidCategoryException.UpsertDataList(
                        key: parametr,
                        value: rule.Message);
                }
            }
            invalidCategoryException.ThrowIfContainsErrors();
        }
    }
}
