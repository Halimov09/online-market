//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Category;
using Market.Api.Models.Foundation.Category.exception;

namespace Market.Api.TestsUnit.services.foundation.category
{
    public partial class CategoryServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationCategoryOnAddIfAndLogicAsync()
        {
            //given
            Category nullCategory = null;
            var nullCategoryException = new NullCategoryException();

            var expectedCategoryExceprion =
                new CategoryValidationException(nullCategoryException);

            //when
            ValueTask<Category> addCategoryTask =
                this.categoryService.AddCategoryAsync(nullCategory);

            //then

        }
    }
}
