using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Game;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Game.WhenToRequestGetAll
{
    public class ReturnGetAll
    {
        private GamesController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_GetAll()
        {
            var serviceMock = new Mock<IGameService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<GameDtoResult>
                {
                    new GameDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new GameDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new GameDtoResult
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new GamesController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as IEnumerable<GameDtoResult>; 
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 3);
        }
        
    }
}