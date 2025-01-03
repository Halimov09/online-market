//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using EFxceptions.Models.Exceptions;
using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Microsoft.Data.SqlClient;
using Moq;

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
            var failedUserStorageException = new FailedUserStorageException(sqlException);

            var expectedUserException =
                new UserDependencyException(failedUserStorageException);

            this.storageBrokerMock.Setup(broker => 
            broker.InsertUsersAsync(someUser))
                .ThrowsAsync(sqlException);

            //when
            ValueTask<Users> addUserTask =
                this.userService.AddUsersAsync(someUser);

            //then
            await Assert.ThrowsAsync<UserDependencyException> (() =>
            addUserTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertUsersAsync(someUser), Times.Once());

            this.loggingBrokerMock.Verify(broker => 
            broker.LogCritical(It.Is(SameExceptionAs(expectedUserException))),
            Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowUserDependencyValidationExceptionOnAddIfAndLogItAsync()
        {
            //given
            Users someUser = CreateRandomUser();
            string someMessage = GetRandomString();

            var duplicateKeyException = 
                new DuplicateKeyException(someMessage);

            var alreadyExistUserException = 
                new AlreadyExisUserException(duplicateKeyException);

            var userDependencyValidationException = 
                new UserDependencyValidationException(alreadyExistUserException);

            this.storageBrokerMock.Setup(broker => 
            broker.InsertUsersAsync(someUser)) .ThrowsAsync(duplicateKeyException);

            //when
            ValueTask<Users> addUserTask =
                this.userService.AddUsersAsync(someUser);

            //then
            await Assert.ThrowsAsync<UserDependencyValidationException> (() => 
            addUserTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
             broker.InsertUsersAsync(someUser), Times.Once());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(userDependencyValidationException))),
            Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowUserServixeExceptionOnAddIfAndLogItAsync()
        {
            //given
            Users someUser = CreateRandomUser();
            var serviceException = new Exception();

            var failedUserException = 
                new FailedUserException(serviceException);

            var expectedUserServiceException =
                new UserserviceException(failedUserException);

            this.storageBrokerMock.Setup(broker =>
            broker.InsertUsersAsync(someUser)) 
                .ThrowsAsync(serviceException);

            //when
            ValueTask<Users> addUseTask =
                this.userService.AddUsersAsync(someUser);

            //then
            await Assert.ThrowsAsync<UserserviceException> (() => 
            addUseTask.AsTask());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertUsersAsync (someUser), Times.Once);

            this.loggingBrokerMock.Verify(broker => 
            broker.LogError(It.Is(SameExceptionAs(expectedUserServiceException))),
            Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
