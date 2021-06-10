using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IStarRepository : IRepository<StarEntity>
    {
        Task<IEnumerable<StarEntity>> FindCompleteByPlayerName(string name);
        Task<IEnumerable<StarEntity>> FindCompleteByGameName(string name);
        Task<IEnumerable<StarEntity>> FindBiggestStar(int amount);
    }
}