//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================


using FluentAssertions;
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
    }
}
