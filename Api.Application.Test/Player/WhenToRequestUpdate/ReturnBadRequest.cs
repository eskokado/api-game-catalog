using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Player;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Player.WhenToRequestUpdate
{
    public class ReturnBadRequest
    {
        private PlayersController _controller;

        [Fact(DisplayName = "É possivel realizar o Updated")]
        public async Task It_is_possible_to_create_Updated()
        {
            var serviceMock = new Mock<IPlayerService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<PlayerDtoUpdate>())).ReturnsAsync(
                new PlayerDtoUpdateResult 
                { 
                    Id = id,
                    Name = name,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new PlayersController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");


            var playerDtoUpdate = new PlayerDtoUpdate
            {
                Id = id,
                Name = name,
                Email = email
            };

            var result = await _controller.Put(playerDtoUpdate);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}