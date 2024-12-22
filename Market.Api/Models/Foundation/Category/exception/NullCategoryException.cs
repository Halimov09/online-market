//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Category.exception
{
    public class NullCategoryException : Xeption
    {
        public NullCategoryException()
            :base(message: "Category is null")
        {}
    }
}
