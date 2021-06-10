using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Game
{
    public class WhenItRunsDeleteGame : GameTest
    {
        private IGameService _service;
        private Mock<IGameService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (Game).")]
        public async Task ItIsPossibleToRunDeleteGame() 
        {
            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(GameId);
            Assert.True(deleted);

            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(GameId);
            Assert.False(deleted);
        }       
    }
}