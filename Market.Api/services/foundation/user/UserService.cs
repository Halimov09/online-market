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
    public partial class UserService : IuserService
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

        public ValueTask<Users> AddUsersAsync(Users users) =>
        TryCatch(async () =>
        {
            ValidateUserNotNull(users);
            return await this.storageBroker.InsertUsersAsync(users);
        });
    }
}
