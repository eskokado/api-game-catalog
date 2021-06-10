using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Game
{
    public class WhenItRunsCreateGame : GameTest
    {
        private IGameService _service;
        private Mock<IGameService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create (Game).")]
        public async Task ItIsPossibleToRunCreateGame() 
        {
            
            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.Post(gameDtoCreate)).ReturnsAsync(gameDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(gameDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(GameId, result.Id);
            Assert.Equal(GameName, result.Name);
        }
        
    }
}