using System;
using Api.Domain.Interfaces.Repositories;
using Api.Infra.Data.Context;
using Api.Infra.Data.Implementations;
using Api.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IPlayerRepository, PlayerImplementation>();
            serviceCollection.AddScoped<IGameRepository, GameImplementation>();
            serviceCollection.AddScoped<IStarRepository, StarImplementation>();

            if (
                Environment.GetEnvironmentVariable("DATABASE").ToLower() ==
                "SQLSERVER".ToLower()
            )
            {
                serviceCollection
                    .AddDbContext<MyContext>(options =>
                        options
                            .UseSqlServer(Environment
                                .GetEnvironmentVariable("DATABASE")));
            }
            else
            {
                string mySqlConnectionStr = Environment.GetEnvironmentVariable("DB_CONNECTION");
                serviceCollection.AddDbContext<MyContext>(
                    options =>
                      options.UseMySql(mySqlConnectionStr,
                                          ServerVersion.AutoDetect(mySqlConnectionStr))
                    );
            }
        }
    }
}