using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IGameRepository : IRepository<GameEntity>
    {
         Task<IEnumerable<GameEntity>> FindByName(string name);
    }
}