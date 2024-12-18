//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class UserValidationExcption : Xeption
    {
        public UserValidationExcption(Xeption innerException)
            :base(message: "User validation error occured, fix the errors and try again",
                 innerException)
        {}
    }
}
