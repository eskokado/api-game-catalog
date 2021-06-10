using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Data.Seeds
{
    public class PlayerSeeds
    {
        public static void Players(ModelBuilder modelBuilder) 
        {
            
            modelBuilder.Entity<PlayerEntity>().HasData(
                new PlayerEntity {
                    Id = Guid.NewGuid(),
                    Name = "User Padrão",
                    Email = "user@example.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new PlayerEntity {
                    Id = Guid.NewGuid(),
                    Name = "Edson Shideki Kokado",
                    Email = "eskokado@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new PlayerEntity {
                    Id = Guid.NewGuid(),
                    Name = "Maria da Silva",
                    Email = "mariasilva@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                },
                new PlayerEntity {
                    Id = Guid.NewGuid(),
                    Name = "José Souza",
                    Email = "josesouza@email.com",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                }
            );

        }
    }
}