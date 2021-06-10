using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Star;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Star
{
    public class WhenItRunsFindCompleteByGameNameStar : StarTest
    {
        private IStarService _service;
        private Mock<IStarService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Find Complete By Game Name (Star).")]
        public async Task ItIsPossibleToRunFindByGameNameStar() 
        {
             _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.FindCompleteByGameName("a")).ReturnsAsync(listStarDto);
            _service = _serviceMock.Object;

            var result = await _service.FindCompleteByGameName("a");
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<StarDtoResult>();
            _serviceMock = new Mock<IStarService>();
            _serviceMock.Setup(m => m.FindCompleteByGameName("a")).ReturnsAsync(_listResult.AsEnumerable<StarDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.FindCompleteByGameName("a");
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}