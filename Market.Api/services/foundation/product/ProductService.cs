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
            ValidateProductOnAdd(product);
            return await this.storageBroker.InsertProductAsync(product);
        });

        public async ValueTask<Product> DeleteProductByIdAsync(Guid productId)
        {
            // Mahsulotni id bo‘yicha topamiz
            Product product = await this.storageBroker.SelectProductByIdAsync(productId);

            // Mahsulot topilmasa, null qaytaramiz yoki maxsus xatolik tashlashimiz mumkin
            if (product == null)
            {
                // Agar xatolikni tashlamoqchi bo'lsangiz, maxsus exception yaratishingiz mumkin
                // throw new ProductNotFoundException($"Product with id {productId} not found.");

                return null; // yoki mos xatolik qaytarish
            }

            // Mahsulotni o‘chirib, uni qaytaramiz
            return await this.storageBroker.DeleteProductAsync(product);
        }
    }
}
