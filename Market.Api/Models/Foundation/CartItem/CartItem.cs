//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.CartItem
{
    public class CartItem
    {
        public Guid Id { get; set; } // Savatcha mahsuloti identifikatori
        public Guid CartId { get; set; } // Savatcha identifikatori
        public Guid ProductId { get; set; } // Mahsulot identifikatori
        public int Quantity { get; set; } // Mahsulot miqdori
    }

}
