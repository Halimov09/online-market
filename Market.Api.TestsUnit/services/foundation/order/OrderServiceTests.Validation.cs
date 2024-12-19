//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Order;
using Market.Api.Models.Foundation.Order.exception;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.order
{
    public partial class OrderServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationOrderExceptionOnAddifAndLogitAsync()
        {
            //given
            Order orderNull = null;
            var orderNullException = new NullOrderException();

            var expectedOrderValidationException = 
                new OrderValidationException(orderNullException);

            //when
            ValueTask<Order> addOrderTask =
                this.orderService.AddOrderAsync(orderNull);

            //then
            await Assert.ThrowsAsync<OrderValidationException> (() =>
            addOrderTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedOrderValidationException))),
            Times.Once());

            this.storageBrokerMock.Verify(broker => 
            broker.InsertOrderAsync(It.IsAny<Order>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
