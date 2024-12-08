﻿//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Users;
using Market.Api.services.foundation.user;
using Moq;
using Tynamix.ObjectFiller;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly IuserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();

            this.userService =
                new UserService(storageBroker: this.storageBrokerMock.Object);
        }

        private static Users CreateRandomUser() =>
             CreateUserFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
                new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Users> CreateUserFiller(DateTimeOffset date)
        {
            var filler = new Filler<Users>();

            filler.Setup().
                OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
