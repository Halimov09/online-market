//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Product;
using Market.Api.services.foundation.product;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.product
{
    public partial class ProductServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly ProductService productService;

        public ProductServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.productService =
                new ProductService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Product CreateRandomProduct() =>
             CreateProductFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
                new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Product> CreateProductFiller(DateTimeOffset date)
        {
            var filler = new Filler<Product>();

            filler.Setup().
                OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
