
using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Infra.Data.Test
{
    public class CrudStarComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudStarComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Star CRUD")]
        [Trait("CRUD", "StarEntity")]
        public async Task It_is_possible_to_perform_Star_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                GameImplementation _gameRepositorio = new GameImplementation(context);
                GameEntity _gameEntity = new GameEntity 
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                };                
                var _game_record_created = await _gameRepositorio.InsertAsync(_gameEntity);

                PlayerImplementation _playerRepositorio = new PlayerImplementation(context);
                PlayerEntity _playerEntity = new PlayerEntity 
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _player_record_created = await _playerRepositorio.InsertAsync(_playerEntity);

                StarImplementation _repositorio = new StarImplementation(context);
                StarEntity _entity = new StarEntity 
                {
                    Id = Guid.NewGuid(),
                    GameId = _game_record_created.Id,
                    PlayerId = _player_record_created.Id,
                    Star = Faker.RandomNumber.Next(0,10)
                };
                
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.GameId, _record_created.GameId);
                Assert.Equal(_entity.PlayerId, _record_created.PlayerId);
                Assert.Equal(_entity.Star, _record_created.Star);
                Assert.False(_record_created.Id == Guid.NewGuid());

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_game_name_a = await _repositorio.FindCompleteByGameName("a");
                var _find_by_game_name_e = await _repositorio.FindCompleteByGameName("e");
                var _find_by_game_name_i = await _repositorio.FindCompleteByGameName("i");
                var _find_by_game_name_o = await _repositorio.FindCompleteByGameName("o");
                Assert.True(
                    _find_by_game_name_a.Count() > 0 ||
                    _find_by_game_name_e.Count() > 0 ||
                    _find_by_game_name_i.Count() > 0 ||
                    _find_by_game_name_o.Count() > 0
                );

                var _find_by_player_name_a = await _repositorio.FindCompleteByPlayerName("a");
                var _find_by_player_name_e = await _repositorio.FindCompleteByPlayerName("e");
                var _find_by_player_name_i = await _repositorio.FindCompleteByPlayerName("i");
                var _find_by_player_name_o = await _repositorio.FindCompleteByPlayerName("o");
                Assert.True(
                    _find_by_player_name_a.Count() > 0 ||
                    _find_by_player_name_e.Count() > 0 ||
                    _find_by_player_name_i.Count() > 0 ||
                    _find_by_player_name_o.Count() > 0
                );

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }  
    }
}