//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using FluentAssertions;
using Market.Api.Models.Foundation.Payment;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.payment
{
    public partial class PaymentServiceTests
    {
        [Fact]
        public async Task ShouldAddPaymentAsync()
        {
            //given
            Payment CreatePayment = CreateRandomPayment();
            Payment inputPayment = CreatePayment;
            Payment returningPayment = inputPayment;
            Payment expectedPayment = returningPayment;

            this.storageBrokerMock.Setup(broker =>
            broker.InsertPaymentAsync(inputPayment)).ReturnsAsync(returningPayment);

            //when
            Payment actualPayment = 
                await this.paymentService.AddPaymentAsync(inputPayment);

            //then
            actualPayment.Should().BeEquivalentTo(expectedPayment);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertPaymentAsync(inputPayment), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
