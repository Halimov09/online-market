//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using EFxceptions.Models.Exceptions;
using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Market.Api.Models.Foundation.Users.exceptions;
using Market.Api.Models.Foundation.Users;
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

        [Fact]
        public async Task ShouldThrowPaymentDependencyValidationExceptionOnAddIfAndLogItAsync()
        {
            //given
            Payment somePayment = CreateRandomPayment();
            string someMessage = GetRandomString();

            var duplicateKeyException = new DuplicateKeyException(someMessage);

            var alreadyExisPaymentException = 
                new AlreadyExisPaymentException(duplicateKeyException);

            var paymentDependencyValidationExcepton = 
                new PaymentDependencyValidationExcepton(alreadyExisPaymentException);

            this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(somePayment)).ThrowsAsync(duplicateKeyException);

            //when
            ValueTask<Payment> addPaymentTask = 
                this.paymentService.AddPaymentAsync(somePayment);

            //then
            await Assert.ThrowsAsync<PaymentDependencyValidationExcepton> (() =>
            addPaymentTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(somePayment), Times.Once);

            this.loggingBrokerMock.Verify(broker => 
            broker.LogError(It.Is(SameExceptionAs(paymentDependencyValidationExcepton))),
            Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowPaymentServixeExceptionOnAddIfAndLogItAsync()
        {
            //given
            Payment somePayment = CreateRandomPayment();
            var serviceException = new Exception();

            var failedUserException =
                new FailedUserException(serviceException);

            var expectedUserServiceException =
                new UserserviceException(failedUserException);

            this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(somePayment))
                .ThrowsAsync(serviceException);

            //when
            ValueTask<Payment> addUseTask =
                this.paymentService.AddPaymentAsync(somePayment);

            //then
            await Assert.ThrowsAsync<UserserviceException>(() =>
            addUseTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(somePayment), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedUserServiceException))),
            Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
