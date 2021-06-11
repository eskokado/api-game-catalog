using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Star.WhenToRequestGetAll
{
    public class ReturnGetAll
    {
        private StarsController _controller;

        [Fact(DisplayName = "É possivel realizar o GetAll")]
        public async Task It_is_possible_GetAll()
        {
            var serviceMock = new Mock<IStarService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<StarDtoResult>
                {
                    new StarDtoResult
                    {
                        Id = Guid.NewGuid(),
                        PlayerId = Guid.NewGuid(),
                        GameId = Guid.NewGuid(),
                        Star = Faker.RandomNumber.Next(0, 10),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new StarDtoResult
                    {
                        Id = Guid.NewGuid(),
                        PlayerId = Guid.NewGuid(),
                        GameId = Guid.NewGuid(),
                        Star = Faker.RandomNumber.Next(0, 10),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    new StarDtoResult
                    {
                        Id = Guid.NewGuid(),
                        PlayerId = Guid.NewGuid(),
                        GameId = Guid.NewGuid(),
                        Star = Faker.RandomNumber.Next(0, 10),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new StarsController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult) result).Value as IEnumerable<StarDtoResult>; 
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 3);
        }
        
    }
}