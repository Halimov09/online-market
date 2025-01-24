//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Product.exception;
using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Microsoft.Data.SqlClient;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowCriticalDependencyExceptionOnDeleteIfLogItAsync()
        {
            // given
            Guid guid = Guid.NewGuid();
            SqlException sqlException = GetSqlError();

            var failedUserStorageException =
                new FailedUserStorageException(sqlException);

            var expectedUserException =
                new UserDependencyException(failedUserStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(guid))
                .Throws(sqlException);

            // when
            ValueTask<Users> deleteUserTask =
                this.userService.DeleteUserByIdAsync(guid);

            // then
            await Assert.ThrowsAsync<UserDependencyException>(() =>
                deleteUserTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(guid), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(expectedUserException))),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
