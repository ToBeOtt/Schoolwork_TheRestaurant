using Microsoft.Extensions.Logging;
using Moq;
using System;
using TheRestaurant.Application.Cart;
using TheRestaurant.Application.Cart.Interfaces;
using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.Carts
{
    public class FetchAllCartItemsTest
    {
        [Fact]
        public async Task FetchAllCartItems_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CartServices>>();
            var cartRepositoryMock = new Mock<ICartRepository>();

            var cartIds = new List<int>
            {
                1, 2
            };

            var cartList = new List<CartResponse>
            {
                new CartResponse ( Id: 1, Name: "cartMock1", Price: 80 ),
                new CartResponse ( Id: 2, Name: "cartMock2", Price: 85 ),
            };


            cartRepositoryMock.Setup
                (repo => repo.GetAllCartItems(cartIds)).ReturnsAsync(cartList);

            var cartService = new CartServices(
                loggerMock.Object,
                cartRepositoryMock.Object
            );

            // Act
            var result = await cartService.FetchAllCartItems(cartIds);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(cartList, result.Data);
            Assert.Null(result.ErrorMessage);
        }

        [Fact]
        public async Task FetchAllCartItems_NoCartItems_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<CartServices>>();
            var cartRepositoryMock = new Mock<ICartRepository>();

            var cartIds = new List<int>
            {
                1, 2
            };


            cartRepositoryMock.Setup
                (repo => repo.GetAllCartItems(cartIds)).ReturnsAsync((List<CartResponse>)null);

            var cartService = new CartServices(
                loggerMock.Object,
                cartRepositoryMock.Object
            );

            // Act
            var result = await cartService.FetchAllCartItems(cartIds);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("CartItems could not be found", result.ErrorMessage);
        }
    }
}