using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Player;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Player.WhenToRequestGet
{
    public class ReturnGet
    {
        private PlayersController _controller;

        [Fact(DisplayName = "É possivel realizar o Get")]
        public async Task It_is_possible_Get()
        {
            var serviceMock = new Mock<IPlayerService>();
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new PlayerDtoResult 
                { 
                    Id = id,
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new PlayersController(serviceMock.Object);

            var result = await _controller.Get(id);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as PlayerDtoResult; 
            Assert.NotNull(resultValue);
            Assert.Equal(id, resultValue.Id);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
 
        }
        
    }
}