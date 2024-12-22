//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Category.exception
{
    public class CategoryValidationException : Xeption
    {
        public CategoryValidationException(Xeption innerException)
            :base(message: "Category validation error occured, fix the error please try again",
                 innerException)
        {}
    }
}
