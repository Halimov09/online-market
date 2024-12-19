//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Review.exception
{
    public class ReviewValidtionException : Xeption
    {
        public ReviewValidtionException(Xeption innerException)
            : base(message: "Review validation error occured, fix the errors and try again", innerException)
        {}
    }
}
