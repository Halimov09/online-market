//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Market.Api.Brokers.Loggings;
using Market.Api.Brokers.Storages;
using Market.Api.Models.Foundation.Users;
using Market.Api.services.foundation.user;
using Moq;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Market.Api.TestsUnit.services.foundation.user
{
    public partial class UserServiceTests
    {
        private readonly Mock<IstorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IuserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IstorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.userService = new UserService(
               storageBroker: this.storageBrokerMock.Object,
               loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Users CreateRandomUser() =>
             CreateUserFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
                new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
            actualException.Message == expectedException.Message 
            && actualException.InnerException.Message == expectedException.InnerException.Message
            && (actualException.InnerException as Xeption).DataEquals(expectedException.InnerException.Data);
        }

        private static Filler<Users> CreateUserFiller(DateTimeOffset date)
        {
            var filler = new Filler<Users>();

            filler.Setup().
                OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
