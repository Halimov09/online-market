//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Order.exception;
using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;
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
        }
        private ProductValidationException CreateAndLogValidationException(Xeption xeption)
        {
            var productValidationException =
                    new ProductValidationException(xeption);

            this.loggingBroker.LogError(productValidationException);

            return productValidationException;
        }
    }
}
