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
            broker.InsertOrderAsync(It.IsAny<Order>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        public async Task ShouldThrowExceptionOnAddIfOrderIsInvalidAndLogitAsync(
            decimal invalidtext)
        {
            //given
            var orderInvalid = new Order
            {
                TotalPrice = invalidtext,
            };

            var invalidOrderException = new InvalidOrderExceptoion();

            invalidOrderException.AddData(
                key: nameof(Order.Id),
                values: "Id is required");

            invalidOrderException.AddData(
                key: nameof(Order.TotalPrice),
                values: "Number is required");

            var expectedOrderException =
                new OrderValidationException(invalidOrderException);

            //when
            ValueTask<Order> addOrderTask =
                this.orderService.AddOrderAsync(orderInvalid);

            //then
            await Assert.ThrowsAsync<OrderValidationException>(() =>
            addOrderTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedOrderException))),
            Times.Once());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertOrderAsync(It.IsAny<Order>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
