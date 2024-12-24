//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Market.Api.Models.Foundation.Product.exception;
using Moq;
using Xunit.Sdk;

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
    }
}
