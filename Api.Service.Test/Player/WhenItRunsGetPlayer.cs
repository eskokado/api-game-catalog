using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Player;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Player
{
    public class WhenItRunsGetPlayer : PlayerTest     
    {
        private IPlayerService _service;
        private Mock<IPlayerService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET (Player).")]
        public async Task ItIsPossibleToRunGetPlayer() 
        {
            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.Get(PlayerId)).ReturnsAsync(playerDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Get(PlayerId);
            Assert.NotNull(result);
            Assert.True(result.Id == PlayerId);
            Assert.Equal(result.Name, PlayerName);
            Assert.Equal(result.Email, PlayerEmail);

            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((PlayerDtoResult) null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(PlayerId);
            Assert.Null(_record);
        }
    }
}