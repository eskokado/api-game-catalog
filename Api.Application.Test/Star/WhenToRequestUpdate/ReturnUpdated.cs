using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Star.WhenToRequestUpdate
{
    public class ReturnUpdated
    {
        private StarsController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IStarService>();
            var id = Guid.NewGuid();
            var playerId = Guid.NewGuid();
            var gameId = Guid.NewGuid();
            var starAmount = Faker.RandomNumber.Next(0, 10);

            serviceMock.Setup(m => m.Put(It.IsAny<StarDtoUpdate>())).ReturnsAsync(
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


            var usermoviesDtoUpdate = new StarDtoUpdate
            {
                Id = id,
                PlayerId = playerId,
                GameId = gameId,
                Star = starAmount,
            };

            var result = await _controller.Put(usermoviesDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as StarDtoResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(playerId, resultValue.PlayerId);
            Assert.Equal(gameId, resultValue.GameId); 
            Assert.Equal(starAmount, resultValue.Star);
 
        }
        
    }
}