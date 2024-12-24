//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Category;

namespace Market.Api.services.foundation.category
{
    public partial class CategoryService : ICategoryService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public CategoryService(
            IstorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {

            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<Category> AddCategoryAsync(Category category) =>
        TryCatch(async () =>
        {
            ValidateCategoryNotNull(category);
            return await this.storageBroker.InsertCategoryAsync(category);
        });
    }
}
