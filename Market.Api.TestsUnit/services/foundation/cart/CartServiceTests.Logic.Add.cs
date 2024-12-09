//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================


using FluentAssertions;
using Market.Api.Models.Foundation.Cart;
using Moq;

namespace Market.Api.TestsUnit.services.foundation.cart
{
    public partial class CartServiceTests
    {
        [Fact]
        public async Task ShouldAddCartAsync()
        {
            //given
            Cart createRandomCart = CreateRandomCart();
            Cart inputCart = createRandomCart;
            Cart returningCart = inputCart;
            Cart expectedCart = returningCart;

            this.storageBrokerMock.Setup(broker => 
            broker.InsertCartAsync(inputCart)).ReturnsAsync(returningCart);

            //when
             Cart actualCart = await this.cartService.AddCartAsync(inputCart);

            //then
            actualCart.Should().BeEquivalentTo(expectedCart);

            this.storageBrokerMock.Verify( broker =>
            broker.InsertCartAsync(inputCart), Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
