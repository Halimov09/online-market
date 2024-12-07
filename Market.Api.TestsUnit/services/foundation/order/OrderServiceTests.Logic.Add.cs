//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Force.DeepCloner;
using Market.Api.Models.Foundation.Order;
using Market.Api.Models.Foundation.Product;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Api.TestsUnit.services.foundation.order
{
    public partial class OrderServiceTests
    {
        [Fact]
        public async Task ShouldAddOrderAsync()
        {
            //given
            Order randomOrder = CreateRandomOrder();
            Order inputOrder = randomOrder;
            Order returningOrder = inputOrder;
            Order expectedOrder = returningOrder.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertOrderAsync(inputOrder)).ReturnsAsync(returningOrder);

            //when 
            Order actualProduct =
                await this.orderService.AddOrderAsync(inputOrder);

            //then
            actualProduct.Should().BeEquivalentTo(expectedOrder);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertOrderAsync(inputOrder), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
