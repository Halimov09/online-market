//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Category;
using Market.Api.services.foundation.category;
using Moq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.category
{
    public partial class CategoryServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly CategoryService categoryService;

        public CategoryServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.categoryService =
                new CategoryService(
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Category CreateRandomCategory() =>
            CreateCategoryFiller().Create();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedCategoryException)
        {
            return actualCategoryException =>
            actualCategoryException.Message == expectedCategoryException.Message &&
            actualCategoryException.InnerException.Message ==
            expectedCategoryException.InnerException.Message
            && (actualCategoryException.InnerException as Xeption)
            .DataEquals(expectedCategoryException.Data);
        }

        private static Filler<Category> CreateCategoryFiller() => new Filler<Category>();
    }
}
