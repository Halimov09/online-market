//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.Review
{
    public class Review
    {
        public int Id { get; set; } // Sharh identifikatori
        public int UserId { get; set; } // Foydalanuvchi identifikatori
        public int ProductId { get; set; } // Mahsulot identifikatori
        public int Rating { get; set; } // Reyting (1–5)
        public string Comment { get; set; } // Foydalanuvchi izohi
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Sharh qo‘shilgan vaqt
    }

}
