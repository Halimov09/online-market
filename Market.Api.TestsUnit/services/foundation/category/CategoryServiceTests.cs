//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Category;
using Market.Api.services.foundation.category;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.category
{
    public partial class CategoryServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly CategoryService categoryService;

        public CategoryServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.categoryService =
                new CategoryService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Category CreateRandomCategory() =>
            CreateCategoryFiller().Create();

        private static Filler<Category> CreateCategoryFiller() => new Filler<Category>();
    }
}
