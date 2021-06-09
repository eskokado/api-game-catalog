using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepository<PlayerEntity>
    {
        Task<PlayerEntity> FindByLogin (string email);
        Task<IEnumerable<PlayerEntity>> FindByName(string name);
    }
}