//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Market.Api.Models.Foundation.Users;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldDeleteUserByIdAsync()
        {
            //given
            Guid randomUserId = Guid.NewGuid();
            Guid inputUserId = randomUserId;
            Users storageUser = CreateRandomUser();
            storageUser.Id = inputUserId;

            this.storageBrokerMock.Setup(broker =>
             broker.SelectUserByIdAsync(inputUserId))
                .ReturnsAsync(storageUser);

            this.storageBrokerMock.Setup(broker =>
            broker.DeleteUsersAsync(storageUser))
                .ReturnsAsync(storageUser);

            //when
            Users actualUser = 
                await this.userService.DeleteUserByIdAsync(inputUserId);

            //then
            actualUser.Should().BeEquivalentTo(storageUser);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectUserByIdAsync(inputUserId), Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteUsersAsync(storageUser), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
