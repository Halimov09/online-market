﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfUserNullAndLogitAsync()
        {
            //given
            Users nullUser = null;
            var nullUserException = new NullUserException();

            var expectedUserValidationException = 
                new UserValidationExcption(nullUserException);

            //when
            ValueTask<Users> addUserTask = 
                this.userService.AddUsersAsync(nullUser);

            //then
            await Assert.ThrowsAsync<UserValidationExcption>(() =>
            addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
            broker.LogError(It.Is(SameExceptionAs(expectedUserValidationException))), 
            Times.Once);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertUsersAsync(It.IsAny<Users>()), 
            Times.Never);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
