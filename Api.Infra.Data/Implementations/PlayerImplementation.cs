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
    public class PlayerImplementation : BaseRepository<PlayerEntity>, IPlayerRepository
    {
        private DbSet<PlayerEntity> _dataset;
        
        public PlayerImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<PlayerEntity> ();
        }

        public async Task<PlayerEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(p => p.Email.Equals(email));
        }

        public async Task<IEnumerable<PlayerEntity>> FindByName(string name) => await _dataset.AsQueryable().Where(p => p.Name.Contains(name)).ToListAsync<PlayerEntity>();
    }
}