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
        private void ValidateCategoryNotNull(Category category)
        {
            if (category is null)
            {
                throw new NullCategoryException();
            }
        }
    }
}
