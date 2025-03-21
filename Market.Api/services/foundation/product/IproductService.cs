//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;

namespace Market.Api.services.foundation.product
{
    public interface IproductService
    {
        ValueTask<Products> AddProductAsync(Products product);
        ValueTask<Products> DeleteProductByIdAsync(Guid productId);
    }
}
