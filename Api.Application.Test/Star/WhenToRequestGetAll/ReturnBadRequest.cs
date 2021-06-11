using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Api.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Star.WhenToRequestGetAll
{
    public class ReturnBadRequest
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
                    }
                }
            );

            _controller = new StarsController(serviceMock.Object);
            _controller
                .ModelState
                .AddModelError("Root", "Rota Inválida");


            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }   
        
    }
}