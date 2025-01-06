//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using EFxceptions.Models.Exceptions;
using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
using Market.Api.Models.Foundation.Users.exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace Market.Api.services.foundation.product
{
    public partial class ProductService
    {
        private delegate ValueTask<Product> ReturningProductExceptions();

        private async ValueTask<Product> TryCatch(ReturningProductExceptions returningProductExceptions)
        {
            try
            {
                return await returningProductExceptions();
            }
            catch (NullProductException nullProductException)
            {
                throw CreateAndLogValidationException(nullProductException);
            }
            catch (InvalidProductException invalidProductException)
            {
                throw CreateAndLogValidationException(invalidProductException);
            }
            catch (SqlException sqlException)
            {
                var failedProductException = new FailedProductException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedProductException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyProductException = new AlreadyExisProductException(duplicateKeyException);

                throw CreateAndLogValidationDependencyException(alreadyProductException);
            }
            catch(Exception exception)
            {
                var productServiceException = new FailedProductException(exception);

                throw CreateAndLogProductServiceException(productServiceException);
            }
        }
        private ProductValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var productValidationException =
                    new ProductValidationException(xeption);

            this.loggingBroker.LogError(productValidationException);

            return productValidationException;
        }

        private ProductDependencyException CreateAndLogCriticalDependencyException(Xeption xception)
        {
            var productDependencyException =
                new ProductDependencyException(xception);

            this.loggingBroker.LogCritical(productDependencyException);

            return productDependencyException;
        }

        private ProductDependencyValidationException CreateAndLogValidationDependencyException(Xeption xeption)
        {
            var productDependencyValidationException =
                new ProductDependencyValidationException(xeption);

            this.loggingBroker.LogError(productDependencyValidationException);

            return productDependencyValidationException;
        }

        private ProductServiceException CreateAndLogProductServiceException(Xeption xeption)
        {
            var productServiceException =
                new ProductServiceException(xeption);

            this.loggingBroker.LogError(productServiceException);

            return productServiceException;
        }
    }
}
