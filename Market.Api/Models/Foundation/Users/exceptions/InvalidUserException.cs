//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class InvalidUserException : Xeption
    {
        public InvalidUserException()
            :base(message: "User is invalid")
        {}
    }
}
