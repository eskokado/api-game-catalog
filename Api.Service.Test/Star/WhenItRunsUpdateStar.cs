using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Star
{
    public class WhenItRunsUpdateStar : StarTest
    {
        private IStarService _service;
        private Mock<IStarService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Update (Star).")]
        public async Task ItIsPossibleToRunUpdateStar() 
        {
            _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.Put(starDtoUpdate)).ReturnsAsync(starDtoResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(starDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(StarId, result.Id);
            Assert.Equal(StarGameId, result.GameId);
            Assert.Equal(StarPlayerId, result.PlayerId);
            Assert.Equal(StarAmount, result.Star);
        }
    }
}