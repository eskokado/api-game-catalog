using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Star
{
    public class WhenItRunsFindCompleteByPlayerNameStar : StarTest
    {
        private IStarService _service;
        private Mock<IStarService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Genre Name (Star).")]
        public async Task ItIsPossibleToRunFindByPlayerNameStar() 
        {
             _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.FindCompleteByPlayerName("a")).ReturnsAsync(listStarDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByPlayerName("a");
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<StarDtoResult>();
            _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.FindCompleteByPlayerName("a")).ReturnsAsync(_listResult.AsEnumerable<StarDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByPlayerName("a");
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}