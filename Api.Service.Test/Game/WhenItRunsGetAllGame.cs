using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Game;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Game
{
    public class WhenItRunsGetAllGame : GameTest
    {
        private IGameService _service;
        private Mock<IGameService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET All (Game).")]
        public async Task ItIsPossibleToRunGetAllGame() 
        {
             _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listGameDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<GameDtoResult>();
            _serviceMock = new Mock<IGameService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable<GameDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}