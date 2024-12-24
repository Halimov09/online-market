//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Category;
using Moq;
using Market.Api.Models.Foundation.Order.exception;
using Market.Api.Models.Foundation.Order;

namespace Market.Api.TestsUnit.services.foundation.order
{
    public partial class OrderServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationOrderOnAddIfAndLogicAsync()
        {
            //given
            Order nullOrder = null;
            var nullOrderException = new NullOrderException();

            var expectedOrderExceprion =
                new OrderValidationException(nullOrderException);

            //when
            ValueTask<Order> addOrderTask =
                this.orderService.AddOrderAsync(nullOrder);

            //then
            await Assert.ThrowsAsync<OrderValidationException>(() =>
            addOrderTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedOrderExceprion))), Times.Once());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertCategoryAsync(It.IsAny<Category>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
