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
    public class StarImplementation : BaseRepository<StarEntity>, IStarRepository
    {
        private DbSet<StarEntity> _dataset;
        
        public StarImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<StarEntity> ();
        }

        public async Task<IEnumerable<StarEntity>> FindBiggestStar(int amount)
        {
            return await _dataset.Include(s => s.Game)
                                .Include(s => s.Player).AsQueryable()
                                .OrderByDescending(s => s.Star)
                                .Take(amount).ToListAsync<StarEntity>();
        }

        public async Task<IEnumerable<StarEntity>> FindCompleteByGameName(string name)
        {
            return await _dataset.Include(s => s.Game)
                                .Include(s => s.Player).AsQueryable()
                                .Where(s => s.Game.Name.Contains(name))
                                .ToListAsync<StarEntity>();
        }

        public async Task<IEnumerable<StarEntity>> FindCompleteByPlayerName(string name)
        {
            return await _dataset.Include(s => s.Game)
                                .Include(s => s.Player).AsQueryable()
                                .Where(s => s.Player.Name.Contains(name))
                                .ToListAsync<StarEntity>();
        }
    }
}