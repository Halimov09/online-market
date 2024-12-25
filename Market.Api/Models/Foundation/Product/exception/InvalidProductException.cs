﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Product.exception
{
    public class InvalidProductException : Xeption
    {
        public InvalidProductException()
            :base(message: "Product is invalid")
        { }
    }
}
