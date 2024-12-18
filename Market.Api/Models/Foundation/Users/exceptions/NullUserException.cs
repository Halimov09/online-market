//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class NullUserException : Xeption
    {
        public NullUserException()
             :base(message: "User is null")
        { }
    }
}
