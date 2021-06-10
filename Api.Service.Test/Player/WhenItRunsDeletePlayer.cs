using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Player
{
    public class WhenItRunsDeletePlayer : PlayerTest
    {
        private IPlayerService _service;
        private Mock<IPlayerService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete (Player).")]
        public async Task ItIsPossibleToRunDeletePlayer() 
        {
            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deleted = await _service.Delete(PlayerId);
            Assert.True(deleted);

            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deleted = await _service.Delete(PlayerId);
            Assert.False(deleted);
        }       
    }
}