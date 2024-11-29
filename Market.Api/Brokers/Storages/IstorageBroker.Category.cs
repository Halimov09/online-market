//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Category;

namespace Market.Api.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Category> InsertCategoryAsync(Category category);
    }
}
