using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Game;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Game
{
    public class WhenItRunsGetGame : GameTest     
    {
        private IGameService _service;
        private Mock<IGameService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Game).")]
        public async Task ItIsPossibleToRunGetGame() 
        {
            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(gameDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(GameId);
            Assert.NotNull(result);
            Assert.True(result.Id == GameId);
            Assert.Equal(GameName, result.Name);

            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((GameDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(GameId);
            Assert.Null(_record);
        }
    }
}