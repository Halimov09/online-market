//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Xeptions;

namespace Market.Api.services.foundation.user
{
    public partial class UserService
    {
        private delegate ValueTask<Users> ReturningUserExceptions();

        private async ValueTask<Users> TryCatch(ReturningUserExceptions returningUserExceptions)
        {
            try 
            {
                return await returningUserExceptions();
            }
            catch (NullUserException nullUserException)
            {
                throw CreateAndLogValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateAndLogValidationException(invalidUserException);
            }
        }
        private UserValidationExcption CreateAndLogValidationException(Xeption xeption)
        {
            var userValidationException =
                    new UserValidationExcption(xeption);

            this.loggingBroker.LogError(userValidationException);

            return userValidationException;
        }

    }
}
