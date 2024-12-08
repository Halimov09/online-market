//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Category;

namespace Market.Api.services.foundation.category
{
    public class CategoryService : ICategoryService
    {
        private readonly IstorageBroker storageBroker;

        public CategoryService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Category> AddCategoryAsync(Category category) =>
            await this.storageBroker.InsertCategoryAsync(category);
    }
}
