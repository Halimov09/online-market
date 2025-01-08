//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class AlreadyExisUserException : Xeption
    {
        public AlreadyExisUserException(Exception innerException)
            :base(message: "User already exis error", innerException)
        {}
    }
}
