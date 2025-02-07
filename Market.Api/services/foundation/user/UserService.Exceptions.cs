﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using EFxceptions.Models.Exceptions;
using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace Market.Api.services.foundation.user
{
    public partial class UserService
    {
        private delegate ValueTask<Users> ReturningUserExceptions();
        private delegate IQueryable<Users> ReturningUserFunction();

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
            catch (NotFoundUserException notFoundUserException)
            {
                throw CreateAndLogValidationException(notFoundUserException);
            }
            catch (SqlException sqlExcepion)
            {
                var failedUserStorageException = new FailedUserStorageException(sqlExcepion);

                throw CreateAndLogCriticalDependencyException(failedUserStorageException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyUserException = new AlreadyExisUserException(duplicateKeyException);

                throw CreateAndLogValidationDependencyException(alreadyUserException);
            }
            catch(Exception  exception)
            {
                var failedUserException = new FailedUserException(exception);

                throw CreateAndLogFailedServiceException(failedUserException);
            }
        }

        private IQueryable<Users> TryCatch(ReturningUserFunction
            returningUserFunction)
        {
            try
            {
                return returningUserFunction();
            }
            catch (SqlException sqlException)
            {
                var failedUserStorageException =
                    new FailedUserStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedUserStorageException);
            }
        }

        private UserValidationExcption CreateAndLogValidationException(Xeption xeption)
        {
            var userValidationException =
                    new UserValidationExcption(xeption);

            this.loggingBroker.LogError(userValidationException);

            return userValidationException;
        }

        private UserDependencyException CreateAndLogCriticalDependencyException(Xeption xeption)
        {
            var userDependencyException = new 
                UserDependencyException(xeption);

            this.loggingBroker.LogCritical(userDependencyException);

            return userDependencyException;
        }

        private UserDependencyValidationException CreateAndLogValidationDependencyException(Xeption xeption)
        {
            var userDependencyValidationException = 
                new UserDependencyValidationException(xeption);

            this.loggingBroker.LogError(userDependencyValidationException);

            return userDependencyValidationException;
        }

        private UserserviceException CreateAndLogFailedServiceException(Xeption xeption)
        {
            var userserviceException =
                new UserserviceException(xeption);

            this.loggingBroker.LogError(userserviceException);

            return userserviceException;
        }
    }
}
