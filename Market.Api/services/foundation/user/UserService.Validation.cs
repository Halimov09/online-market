//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;

namespace Market.Api.services.foundation.user
{
    public partial class UserService
    {
        private void ValidateUserNotNull(Users users)
        {
            if (users is null)
            {
                throw new NullUserException();
            }
        }
    }
}
