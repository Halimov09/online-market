//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Microsoft.Data.SqlClient;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.payment
{
    public partial class PaymentServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionPaymentOnAddIfAndLogItAsync()
        {
            //given
            Payment somePayment = CreateRandomPayment();
            SqlException sqlException = GetSqlError();

            var failedPaymentStorageException = new FailedPaymentStorageException(sqlException);

            var expectedDependencyException = 
                new PaymentDependencyException(failedPaymentStorageException);

            this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(somePayment)).ThrowsAsync(sqlException);

            //when
            ValueTask<Payment> addPaymentTask =
                this.paymentService.AddPaymentAsync(somePayment);

            //then
            await Assert.ThrowsAsync<PaymentDependencyException> (() =>
            addPaymentTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(somePayment), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogCritical(It.Is(SameExceptionAs(expectedDependencyException))),
            Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
