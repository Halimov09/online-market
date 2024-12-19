//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Moq;
using Xunit.Sdk;

namespace Market.Api.TestsUnit.services.foundation.payment
{
    public partial class PaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowExceptionOnAddIfPaymentNullAndLogitAsync()
        {
            //given
            Payment paymentNull = null;
            var paymetNullException = new NullPaymentException();

            var expectedNullPaymentException = 
                new PaymentValidationException(paymetNullException);

            //when
            ValueTask<Payment> addPaymentTask =
                this.paymentService.AddPaymentAsync(paymentNull);

            //then
            await Assert.ThrowsAsync<PaymentValidationException> (() =>
            addPaymentTask.AsTask ());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedNullPaymentException))), 
            Times.Once());

            this.storageBrokerMock.Verify(broker => 
            broker.InsertPaymentAsync(It.IsAny<Payment>()), Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
