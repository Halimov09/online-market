//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Category;
using Market.Api.Models.Foundation.Category.exception;

namespace Market.Api.services.foundation.category
{
    public class CategoryService : ICategoryService
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

        public async ValueTask<Category> AddCategoryAsync(Category category)
        {
            try
            {
                if (category is null)
                {
                    throw new NullCategoryException();
                }
                return await this.storageBroker.InsertCategoryAsync(category);
            }
            catch (NullCategoryException nullCategoryException)
            {
                var actualCategoryException = 
                    new CategoryValidationException(nullCategoryException);

                this.loggingBroker.LogError(actualCategoryException);

                throw actualCategoryException;
            }
        }
    }
}
