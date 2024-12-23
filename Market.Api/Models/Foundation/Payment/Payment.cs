﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.Payment
{
    public class Payment
    {
        public int Id { get; set; } // To‘lov identifikatori
        public int OrderId { get; set; } // Buyurtma identifikatori
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow; // To‘lov sanasi
        public decimal Amount { get; set; } // To‘langan summa
        public PaymentMethod Method { get; set; } // To‘lov usuli
    }

}
