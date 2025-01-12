//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using EFxceptions.Models.Exceptions;
using Market.Api.Models.Foundation.Payment;
using Market.Api.Models.Foundation.Payment.exception;
using Market.Api.Models.Foundation.Users.exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace Market.Api.services.foundation.payment
{
    public partial class PaymentService
    {
        private delegate ValueTask<Payment> ReturningPaymentExceptions();

        private async ValueTask<Payment> TryCatch(ReturningPaymentExceptions returningPaymentExceptions)
        {
            try
            {
                return await returningPaymentExceptions();
            }
            catch (NullPaymentException nullPaymentException)
            {
                throw CreateAndLogValidationException(nullPaymentException);
            }
            catch (InvalidPaymentException invalidPaymentException)
            {
                throw CreateAndLogValidationException(invalidPaymentException);
            }
            catch(SqlException sqlException)
            {
                var failedPaymentStorageException = new FailedPaymentStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedPaymentStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExisPaymentException = new AlreadyExisPaymentException(duplicateKeyException);

                throw CreateAndLogValidationDependencyException(alreadyExisPaymentException);
            }
            catch (Exception exception)
            {
                var failedPaymentException = new FiledPaymentException(exception);

                throw CreateAndLogFailedServiceException(failedPaymentException);
            }
        }
        private PaymentValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var paymentValidationException =
                    new PaymentValidationException(xeption);

            this.loggingBroker.LogError(paymentValidationException);

            return paymentValidationException;
        }

        private PaymentDependencyException CreateAndLogCriticalDependencyException(Xeption xeption)
        {
            var paymentDependencyException =
                new PaymentDependencyException(xeption);

            this.loggingBroker.LogCritical(paymentDependencyException);

            return paymentDependencyException;
        }

        private PaymentDependencyValidationExcepton CreateAndLogValidationDependencyException(Xeption xeption)
        {
            var paymentDependencyValidationExcepton =
                new PaymentDependencyValidationExcepton(xeption);

            this.loggingBroker.LogError(paymentDependencyValidationExcepton);

            return paymentDependencyValidationExcepton;
        }

        private PaymentServiceException CreateAndLogFailedServiceException(Xeption xeption)
        {
            var paymentserviceException =
                new PaymentServiceException(xeption);

            this.loggingBroker.LogError(paymentserviceException);

            return paymentserviceException;
        }
    }
}
