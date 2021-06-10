using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Game
{
    public class WhenItRunsUpdateGame : GameTest
    {
        private IGameService _service;
        private Mock<IGameService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Game).")]
        public async Task ItIsPossibleToRunUpdateGame() 
        {
            
            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.Put(gameDtoUpdate)).ReturnsAsync(gameDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(gameDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(GameId, result.Id);
            Assert.Equal(GameNameUpdate, result.Name);
        }
        
    }
}