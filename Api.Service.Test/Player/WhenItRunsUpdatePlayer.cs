using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Player
{
    public class WhenItRunsUpdatePlayer : PlayerTest
    {
        private IPlayerService _service;
        private Mock<IPlayerService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Player).")]
        public async Task ItIsPossibleToRunUpdatePlayer() 
        {
            
            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.Put(playerDtoUpdate)).ReturnsAsync(playerDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(playerDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(PlayerId, result.Id);
            Assert.Equal(PlayerNameUpdate, result.Name);
            Assert.Equal(PlayerEmailUpdate, result.Email);
        }
        
    }
}