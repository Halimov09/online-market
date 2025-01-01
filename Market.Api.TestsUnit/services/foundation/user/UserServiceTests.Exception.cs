//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Microsoft.Data.SqlClient;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnAddIfSqlErrorOccurceAndLogItAsync()
        {
            //given
            Users someUser = CreateRandomUser();
            SqlException sqlException = GetSqlError();

            //when

            //then
        }
    }
}
