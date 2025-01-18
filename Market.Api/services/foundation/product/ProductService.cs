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
            ValidateProductOnAdd(product);
            return await this.storageBroker.InsertProductAsync(product);
        });

        public ValueTask<Product> DeleteProductByIdAsync(Guid productId) =>
        TryCatch(async () =>
        {
            ValidateProductIdDelete(productId);

            // Mahsulotni id bo‘yicha topamiz
            Product product = await this.storageBroker.SelectProductByIdAsync(productId);

            // Mahsulot topilmasa, xatolik tashlaymiz
            if (product == null)
            {
                throw new NotFoundProductException(productId);
            }

            // Mahsulotni o‘chirib, uni qaytaramiz
            return await this.storageBroker.DeleteProductAsync(product);
        });
    }
}
