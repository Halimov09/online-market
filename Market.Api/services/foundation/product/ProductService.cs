//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Product;

namespace Market.Api.services.foundation.product
{
    public class ProductService : IproductService
    {
        private readonly IstorageBroker storageBroker;

        public ProductService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Product> AddProductAsync(Product product) =>
            await this.storageBroker.InsertProductAsync(product);
    }
}
