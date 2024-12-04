//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Users;

namespace Market.Api.services.foundation.user
{
    public class UserService : IuserService
    {
        private readonly IstorageBroker storageBroker;

        public UserService(IstorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public ValueTask<Users> AddUsersAsync() => 
            throw new NotImplementedException();
    }
}
