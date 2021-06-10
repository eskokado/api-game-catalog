using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Star
{
    public class WhenItRunsGetStar : StarTest     
    {
        private IStarService _service;
        private Mock<IStarService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Star).")]
        public async Task ItIsPossibleToRunGetStar() 
        {
            _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.Get(StarId)).ReturnsAsync(starDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(StarId);
            Assert.NotNull(result);
            Assert.True(result.Id == StarId);
            Assert.Equal(StarGameId, result.GameId);
            Assert.Equal(StarPlayerId, result.PlayerId);
            Assert.Equal(StarAmount, result.Star);

            _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((StarDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(StarId);
            Assert.Null(_record);
        }
    }
}