using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Game;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Game.WhenToRequestCreated
{
    public class ReturnBadRequest
    {
        private GamesController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IGameService>();
            var name = Faker.Name.FullName();

            serviceMock
                .Setup(m => m.Post(It.IsAny<GameDtoCreate>()))
                .ReturnsAsync(new GameDtoCreateResult {
                    Id = Guid.NewGuid(),
                    Name = name,
                    CreateAt = DateTime.UtcNow
                });

            _controller = new GamesController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Name", "É um campo obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url
                .Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                .Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var gameDtoCreate =
                new GameDtoCreate { Name = name };

            var result = await _controller.Post(gameDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
