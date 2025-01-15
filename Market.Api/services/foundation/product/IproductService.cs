//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;

namespace Market.Api.services.foundation.product
{
    public interface IproductService
    {
        ValueTask<Product> AddProductAsync(Product product);
        ValueTask<Product> DeleteProductByIdAsync(Guid productId);
    }
}
