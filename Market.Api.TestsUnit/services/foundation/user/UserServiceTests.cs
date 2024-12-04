//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Users;
using Market.Api.services.foundation.user;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public class UserServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly IuserService userService;

        public UserServiceTests() 
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.userService =
                new UserService(storageBroker: this.storageBrokerMock.Object);
        }

        [Fact]
        public async Task ShouldAddUserAsync()
        {
            //arrange
            Users randomUser = new Users()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "ohef@gmail.com",
                Password = "password",
                Role = Role.Admin,
                CreateDate = DateTime.Now,
            };

            this.storageBrokerMock.Setup(broker =>
            broker.InsertUsersAsync(randomUser))
                .ReturnsAsync(randomUser);

            //act 
            Users actual = await this.userService.AddUsersAsync(randomUser);

            //assert
            actual.Should().BeEquivalentTo(randomUser);
        }
    }
}
