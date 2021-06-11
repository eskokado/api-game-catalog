using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Player;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Player.WhenToRequestCreated
{
    public class ReturnCreated
    {
        private PlayersController _controller;

        [Fact(DisplayName = "É possivel realizar o Created")]
        public async Task It_is_possible_to_create_Created()
        {
            var serviceMock = new Mock<IPlayerService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<PlayerDtoCreate>())).ReturnsAsync(
                new PlayerDtoCreateResult 
                { 
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new PlayersController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var playerDtoCreate = new PlayerDtoCreate
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(playerDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult) result).Value as PlayerDtoCreateResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(playerDtoCreate.Name, resultValue.Name);
            Assert.Equal(playerDtoCreate.Email, resultValue.Email);
        }
    }
}