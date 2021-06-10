
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
    public class CrudGameComplet : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CrudGameComplet(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Game CRUD")]
        [Trait("CRUD", "GameEntity")]
        public async Task It_is_possible_to_perform_Game_CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                GameImplementation _repositorio = new GameImplementation(context);
                GameEntity _entity = new GameEntity 
                {
                    Name = Faker.Name.FullName()
                };
                var _record_created = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_record_created);
                Assert.Equal(_entity.Name, _record_created.Name);
                Assert.False(_record_created.Id == Guid.NewGuid());

                _entity = _record_created;
                _entity.Name = Faker.Name.First();

                var _record_update = await _repositorio.UpdateAsync(_entity);
                Assert.Equal(_entity, _record_update);
                Assert.True(_record_update.Id == _entity.Id);

                var _record_exists = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(_record_exists);

                var _find_by_login = await _repositorio.FindByName(_entity.Name);
                Assert.True(_find_by_login.Count() > 0);

                var _selected = await _repositorio.SelectAsync(_entity.Id);
                Assert.Equal(_entity, _selected);

                var _removed = await _repositorio.DeleteAsync(_entity.Id);
                Assert.True(_removed);
            }
        }  
    }
}