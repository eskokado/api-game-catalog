using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Seeds
{
    public class GameSeeds
    {
        public static void Games(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameEntity>().HasData(
                new GameEntity()
                {
                    Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                    Name = "Dra Pirilau",
                    CreateAt = DateTime.UtcNow
                },
                new GameEntity()
                {
                    Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                    Name = "XanaCarnivora",
                    CreateAt = DateTime.UtcNow
                },
                new GameEntity()
                {
                    Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                    Name = "Dapra20comer",
                    CreateAt = DateTime.UtcNow
                },
                 new GameEntity()
                 {
                     Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                     Name = "Tatycomendo",
                     CreateAt = DateTime.UtcNow
                 },
                 new GameEntity()
                 {
                     Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                     Name = "Uhpapaichegou",
                     CreateAt = DateTime.UtcNow
                 }
            );
        }

    }
}