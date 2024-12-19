//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Review.exception
{
    public class NullReviewException : Xeption
    {
        public NullReviewException()
            :base(message: "Review is null")
        {}
    }
}
