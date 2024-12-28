//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.OrderItem
{
    public class OrderItem
    {
        public Guid Id { get; set; } // Buyurtma mahsuloti identifikatori
        public Guid OrderId { get; set; } // Buyurtma identifikatori
        public Guid ProductId { get; set; } // Mahsulot identifikatori
        public int Quantity { get; set; } // Mahsulot miqdori
        public decimal Price { get; set; } // Mahsulotning narxi
    }

}
