using Api.Domain.Entities;
using Api.Infra.Data.Mapping;
using Api.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<StarEntity> Stars { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<PlayerEntity> (new PlayerMap().Configure);

            modelBuilder.Entity<GameEntity> (new GameMap().Configure);
            modelBuilder.Entity<StarEntity> (new StarMap().Configure);

            PlayerSeeds.Players(modelBuilder);
            GameSeeds.Games(modelBuilder);
        }
    }
}