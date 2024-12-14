//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Force.DeepCloner;
using Market.Api.Models.Foundation.Users;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldAddUserAsync()
        {
            //given
            Users randomUser = CreateRandomUser();
            Users inputUser = randomUser;
            Users returningUser = inputUser;
            Users expectedUser = returningUser.DeepClone();

            this.storageBrokerMock.Setup(broker => broker.InsertUsersAsync(inputUser))
                .ReturnsAsync(returningUser);

            //when
            Users actualUser = 
                await this.userService.AddUsersAsync(inputUser);

            //then
            actualUser.Should().BeEquivalentTo(expectedUser);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertUsersAsync(inputUser), Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
