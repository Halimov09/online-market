//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Product;

namespace Market.Api.services.foundation.product
{
    public partial class ProductService : IproductService
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

        public ValueTask<Product> AddProductAsync(Product product) =>
        TryCatch(async () =>
        {
            ValidateProductNotNull(product);
            return await this.storageBroker.InsertProductAsync(product);
        });
    }
}
