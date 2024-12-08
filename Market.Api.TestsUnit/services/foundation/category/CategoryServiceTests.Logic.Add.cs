//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Force.DeepCloner;
using Market.Api.Models.Foundation.Category;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Api.TestsUnit.services.foundation.category
{
    public partial class CategoryServiceTests
    {
        [Fact]
        public async Task ShouldAddCategoryAsync()
        {
            //given
            Category randomCategory = CreateRandomCategory();
            Category inputCategory = randomCategory;
            Category returningCategory = inputCategory;
            Category expectedCategory = returningCategory.DeepClone();

            this.storageBrokerMock.Setup(broker => 
            broker.InsertCategoryAsync(inputCategory)).ReturnsAsync(returningCategory);

            //when
            Category actualCategory = 
                await this.categoryService.AddCategoryAsync(inputCategory);

            //then
            actualCategory.Should().BeEquivalentTo(expectedCategory);

            this.storageBrokerMock.Verify(broker => 
            broker.InsertCategoryAsync(inputCategory), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
