//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.Order
{
    public class Order
    {
        public Guid Id { get; set; } // Buyurtma identifikatori
        public Guid UserId { get; set; } // Foydalanuvchi identifikatori
        public decimal TotalPrice { get; set; } // Buyurtma umumiy summasi
        public DateTime OrderDate { get; set; } // Buyurtma sanasi
        public OrderStatus orderStatus { get; set; } // Buyurtma holati (enum)
    }
}
