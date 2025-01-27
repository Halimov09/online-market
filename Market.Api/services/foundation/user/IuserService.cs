//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;

namespace Market.Api.services.foundation.user
{
    public interface IuserService
    {
        ValueTask<Users> AddUsersAsync(Users users);
        ValueTask<Users> DeleteUserByIdAsync(Guid usersId);
        IQueryable<Users> RetrieveAllUsers();
    }
}
