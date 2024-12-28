//==================================================
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnAddIfInvalidAndLogitAsync
            (string invalidText)
        {
            //given
            var invalidUser = new Users
            {
                Name = invalidText,
            };

            var invalidUserException = new InvalidUserException();

            invalidUserException.AddData(
                key: nameof(Users.Id),
                values: "Id is required");

            invalidUserException.AddData(
                key: nameof(Users.Name),
                values: "Text is required");

            invalidUserException.AddData(
                key: nameof(Users.Email),
                values: "Text is required");

            invalidUserException.AddData(
                key: nameof(Users.Password),
                values: "Text is required");

            var expectedUserValidationException = 
                new UserValidationExcption(invalidUserException);

            //when
            ValueTask<Users> addUserTask =
                this.userService.AddUsersAsync(invalidUser);

            //then
            await Assert.ThrowsAsync<UserValidationExcption> (() =>
            addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker => 
            broker.LogError(It.Is(SameExceptionAs(expectedUserValidationException))),
                Times.Once());

            this.storageBrokerMock.Verify(broker =>
            broker.InsertUsersAsync(It.IsAny<Users>()),
            Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfEnumUserAndLogitAsync()
        {
            //given
            Users randomUser = CreateRandomUser();
            Users invalidUser = randomUser;
            invalidUser.Role = GetInvalidEnum<Role>();

            var invalidUserException = new InvalidUserException();

            invalidUserException.AddData(
                key: nameof(Users.Role),
                values: "Value is invalid");

            var expectedUserException = 
                new UserValidationExcption(invalidUserException);

            //when
            ValueTask<Users> addUserTask =
                this.userService.AddUsersAsync(invalidUser);

            //then
            await Assert.ThrowsAsync<UserValidationExcption> (() =>
            addUserTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
             broker.LogError(It.Is(SameExceptionAs(expectedUserException))),
             Times.Once());

            this.storageBrokerMock.Verify(broker => 
            broker.InsertUsersAsync (It.IsAny<Users>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

    }
}
