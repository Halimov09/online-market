//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Market.Api.Models.Foundation.Product.exception;
using Market.Api.Models.Foundation.Users.exceptions;
using Market.Api.Models.Foundation.Users;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.payment
{
    public partial class PaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowExceptionOnAddIfPaymentIsNullAndLogitAsync()
        {
            //given
            Payment nullPayment = null;
            var nullPaymentException = new NullPaymentException();


            var expectedProductException =
                new ProductValidationException(nullPaymentException);

            //when
            ValueTask<Payment> AddPaymentask =
                this.paymentService.AddPaymentAsync(nullPayment);

            //then
            await Assert.ThrowsAsync<PaymentValidationException>(() =>
            AddPaymentask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedProductException))),
            Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()),
            Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        public async Task ShouldThrowExceptionOnAddIfPaymentIsInvalidAndLogitAsync(
            int invalidtext)
        {
            //given
            var paymentInvalid = new Payment
            {
                Amount = invalidtext,
            };

            var invalidPaymentException = new InvalidPaymentException();

            invalidPaymentException.AddData(
                key: nameof(Payment.Id),
                values: "Id is required");

            invalidPaymentException.AddData(
                key: nameof(Payment.OrderId),
                values: "CategoryId is required");

            invalidPaymentException.AddData(
                key: nameof(Payment.Amount),
                values: "Number is required");

            var expectedPaymentException =
                new PaymentValidationException(invalidPaymentException);

            //when
            ValueTask<Payment> addProductTask =
                this.paymentService.AddPaymentAsync(paymentInvalid);

            //then
            await Assert.ThrowsAsync<PaymentValidationException>(() =>
            addProductTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedPaymentException))),
            Times.Once());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfEnumPaymentAndLogitAsync()
        {
            //given
            Payment randomPayment = CreateRandomPayment();
            Payment invalidPayment = randomPayment;
            invalidPayment.paymentMethod = GetInvalidEnum<PaymentMethod>();

            var invalidPaymentException = new InvalidPaymentException();

            invalidPaymentException.AddData(
                key: nameof(Payment.paymentMethod),
                values: "Value is invalid");

            var expectedPaymentException =
                new PaymentValidationException(invalidPaymentException);

            //when
            ValueTask<Payment> addUserTask =
                this.paymentService.AddPaymentAsync(invalidPayment);

            //then
            await Assert.ThrowsAsync<PaymentValidationException>(() =>
            addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
             broker.LogError(It.Is(SameExceptionAs(expectedPaymentException))),
             Times.Once());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(It.IsAny<Payment>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
