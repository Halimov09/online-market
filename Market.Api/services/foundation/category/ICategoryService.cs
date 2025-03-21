//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Categorys;

namespace Market.Api.services.foundation.category
{
    public interface ICategoryService
    {
        ValueTask<Category> AddCategoryAsync(Category category);
    }
}
