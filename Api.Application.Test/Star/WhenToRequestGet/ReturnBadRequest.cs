using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Star.WhenToRequestGet
{
    public class ReturnBadRequest
    {
        private StarsController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get
        ()
        {
            var serviceMock = new Mock<IStarService>();
            var id = Guid.NewGuid();
            var playerId = Guid.NewGuid();
            var gameId = Guid.NewGuid();
            var starAmount = Faker.RandomNumber.Next(0,10);

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
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
            _controller
                .ModelState
                .AddModelError("Id", "Registro inexistente");


            var result = await _controller.Get(id);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}