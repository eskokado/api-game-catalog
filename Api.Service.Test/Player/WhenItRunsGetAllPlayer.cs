using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Player;
using Api.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.Player
{
    public class WhenItRunsGetAllPlayer : PlayerTest
    {
        private IPlayerService _service;
        private Mock<IPlayerService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET All (Player).")]
        public async Task ItIsPossibleToRunGetAllPlayer() 
        {
             _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listPlayerDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<PlayerDtoResult>();
            _serviceMock = new Mock<IPlayerService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable<PlayerDtoResult>);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}