using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Game;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Game.WhenToRequestUpdate
{
    public class ReturnBadRequest
    {
        private GamesController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IGameService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();

            serviceMock.Setup(m => m.Put(It.IsAny<GameDtoUpdate>())).ReturnsAsync(
                new GameDtoUpdateResult 
                { 
                    Id = id,
                    Name = name,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new GamesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");


            var gameDtoUpdate = new GameDtoUpdate
            {
                Id = id,
                Name = name,
            };

            var result = await _controller.Put(gameDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}