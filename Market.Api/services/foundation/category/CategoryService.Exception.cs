//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Categorys.exception;
using Market.Api.Models.Foundation.Categorys;
using Xeptions;

namespace Market.Api.services.foundation.category
{
    public partial class CategoryService
    {
        private delegate ValueTask<Category> ReturningCategoryExceptions();

        private async ValueTask<Category> TryCatch(ReturningCategoryExceptions returningCategoryExceptions)
        {
            try
            {
                return await returningCategoryExceptions();
            }
            catch (NullCategoryException nullCategoryException)
            {
                throw CreateAndLogValidationException(nullCategoryException);
            }
            catch(InvalidCategoryException invalidCategoryException)
            {
                throw CreateAndLogValidationException(invalidCategoryException);
            }
        }
        private CategoryValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var categoryValidationException =
                    new CategoryValidationException(xeption);

            this.loggingBroker.LogError(categoryValidationException);

            return categoryValidationException;
        }
    }
}
