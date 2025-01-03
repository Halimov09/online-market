//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Xeptions;

namespace Market.Api.Models.Foundation.Users.exceptions
{
    public class UserserviceException : Xeption
    {
        public UserserviceException(Xeption innerExcetion)
            :base(message: "User service error occured,contact support", 
                 innerExcetion)
        {}
    }
}
