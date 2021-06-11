using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Star.WhenToRequestCreated
{
    public class ReturnCreated
    {
        private StarsController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IStarService>();
            var id = Guid.NewGuid();
            var playerId = Guid.NewGuid();
            var gameId = Guid.NewGuid();
            var starAmount = Faker.RandomNumber.Next(0,10);

            serviceMock.Setup(m => m.Post(It.IsAny<StarDtoCreate>())).ReturnsAsync(
                new StarDtoResult 
                { 
                    Id = id,
                    PlayerId = playerId,
                    GameId = gameId,
                    Star = starAmount,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new StarsController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var starDtoCreate = new StarDtoCreate
            {
                PlayerId = playerId,
                GameId = gameId,
                Star = starAmount,
            };

            var result = await _controller.Post(starDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult) result).Value as StarDtoResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(starDtoCreate.PlayerId, resultValue.PlayerId);
            Assert.Equal(starDtoCreate.GameId, resultValue.GameId);
            Assert.Equal(starDtoCreate.Star, resultValue.Star);
        }
    }
}