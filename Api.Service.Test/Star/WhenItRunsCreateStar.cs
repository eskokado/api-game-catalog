using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Star
{
    public class WhenItRunsCreateStar : StarTest
    {
        private IStarService _service;
        private Mock<IStarService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Create (Star).")]
        public async Task ItIsPossibleToRunCreateStar() 
        {
            
            _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.Post(starDtoCreate)).ReturnsAsync(starDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(starDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(StarId, result.Id);
            Assert.Equal(StarGameId, result.GameId);
            Assert.Equal(StarAmount, result.Star);
            Assert.Equal(StarPlayerId, result.PlayerId);
        }
        
    }
}