//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.Cart
{
    public class Cart
    {
        public int Id { get; set; } // Savatcha identifikatori
        public int UserId { get; set; } // Foydalanuvchi identifikatori
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Savatcha yaratilgan sana
    }

}
