//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;

namespace Market.Api.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Product> InsertProductAsync(Product product);
        ValueTask<Product> SelectProductByIdAsync(Guid productId);
        ValueTask<Product> DeleteProductAsync(Product product);
    }
}
