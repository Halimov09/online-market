//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Review;

namespace Market.Api.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Review> InsertReviewAsync (Review review);
    }
}
