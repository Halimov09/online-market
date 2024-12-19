//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;

namespace Market.Api.services.foundation.product
{
    public class ProductService : IproductService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ProductService(
            IstorageBroker storageBroker, 
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Product> AddProductAsync(Product product)
        {
            try 
            {
                if (product is null)
                {
                    throw new NullProductException();
                }
                return await this.storageBroker.InsertProductAsync(product);
            }
            catch (NullProductException nullProductException)
            {
                var productValidationException = 
                    new ProductValidationException(nullProductException);

                this.loggingBroker.LogError(productValidationException);

                throw productValidationException;
            }
        }
    }
}
