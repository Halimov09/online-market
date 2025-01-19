//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product;
using Market.Api.Models.Foundation.Users;

namespace Market.Api.Brokers.Storages
{
    public partial interface IstorageBroker
    {
        ValueTask<Users> InsertUsersAsync(Users user);
        ValueTask<Users> SelectUserByIdAsync(Guid usertId);
        ValueTask<Users> DeleteUserAsync(Users users);
    }
}
