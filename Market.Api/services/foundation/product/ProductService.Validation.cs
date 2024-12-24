//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Product.exception;

namespace Market.Api.services.foundation.product
{
    public partial class ProductService
    {
        private void ValidateProductNotNull(Product product)
        {
            if (product is null)
            {
                throw new NullProductException();
            }
        }
    }
}
