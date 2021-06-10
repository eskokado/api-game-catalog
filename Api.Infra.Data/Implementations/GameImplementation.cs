using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Implementations
{
    public class GameImplementation : BaseRepository<GameEntity>, IGameRepository
    {
        private DbSet<GameEntity> _dataset;
        
        public GameImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<GameEntity> ();
        }

        public async Task<IEnumerable<GameEntity>> FindByName(string name)
        {
            return await _dataset.AsQueryable().Where(g => g.Name.Contains(name)).ToListAsync<GameEntity>();
        }
    }
}