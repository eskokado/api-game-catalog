using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Player
{
    public class WhenItRunsCreatePlayer : PlayerTest
    {
        private IPlayerService _service;
        private Mock<IPlayerService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create (Player).")]
        public async Task ItIsPossibleToRunCreatePlayer() 
        {
            
            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.Post(playerDtoCreate)).ReturnsAsync(playerDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(playerDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(PlayerId, result.Id);
            Assert.Equal(PlayerName, result.Name);
            Assert.Equal(PlayerEmail, result.Email);
        }
        
    }
}