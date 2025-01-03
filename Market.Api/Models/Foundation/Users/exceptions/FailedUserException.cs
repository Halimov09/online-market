//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class FailedUserException : Xeption
    {
        public FailedUserException(Exception innerException)
            :base(message: "failed user exception error occured", innerException)
        {}
    }
}
