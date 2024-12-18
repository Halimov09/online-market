//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;

namespace Market.Api.services.foundation.user
{
    public class UserService : IuserService
    {
        private readonly IstorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(
            IstorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Users> AddUsersAsync(Users users)
        {
            try
            {
                if (users is null)
                {
                    throw new NullUserException();
                }
                return await this.storageBroker.InsertUsersAsync(users);
            }
            catch(NullUserException nullUserException)
            {
                var userValidationException =
                    new UserValidationExcption(nullUserException);

                this.loggingBroker.LogError(userValidationException);

                throw userValidationException;
            }
        }
    }
}
