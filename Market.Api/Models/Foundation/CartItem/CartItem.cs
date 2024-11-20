//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

namespace Market.Api.Models.Foundation.CartItem
{
    public class CartItem
    {
        public int Id { get; set; } // Savatcha mahsuloti identifikatori
        public int CartId { get; set; } // Savatcha identifikatori
        public int ProductId { get; set; } // Mahsulot identifikatori
        public int Quantity { get; set; } // Mahsulot miqdori
    }

}
