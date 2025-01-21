//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================


using FluentAssertions;
using Market.Api.Models.Foundation.Product.exception;
using Market.Api.Models.Foundation.Users;
using Market.Api.Models.Foundation.Users.exceptions;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowUserValidationExceptionOnRemoveIfIdIsInvalidAndLogItAsync()
        {
            // given
            Guid invalidUsertId = Guid.Empty;

            var invalidUserException =
                new InvalidUserException();

            invalidUserException.AddData(
                key: nameof(Users.Id),
                values: "Id is required");

            var expectedValidationException =
                new UserValidationExcption(invalidUserException);

            //when
            ValueTask<Users> removeUserById =
                this.userService.DeleteUserByIdAsync(invalidUsertId);

            UserValidationExcption actualCompanyValidationExecption =
                await Assert.ThrowsAsync<UserValidationExcption>(
                    removeUserById.AsTask);

            //then
            actualCompanyValidationExecption.Should().BeEquivalentTo(expectedValidationException);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedValidationException))), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteUsersAsync(It.IsAny<Users>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowNotFoundExceptionOnRemoveUserByIdIsNotFoundAndLogItAsync()
        {
            // given
            Guid inputUserId = Guid.NewGuid();
            Users noUsers = null;

            var notFoundUserException =
                new NotFoundUserException(inputUserId);

            var expectedProductValidationException =
                new UserValidationExcption(notFoundUserException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectUserByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(noUsers);

            // when
            ValueTask<Users> removeUserById =
                this.userService.DeleteUserByIdAsync(inputUserId);

            var actualProductValidationException =
                await Assert.ThrowsAsync<UserValidationExcption>(
                    removeUserById.AsTask);

            // then
            actualProductValidationException.Should().BeEquivalentTo(expectedProductValidationException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(It.IsAny<Guid>()), Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedProductValidationException))), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
