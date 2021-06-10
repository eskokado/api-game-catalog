using System;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infra.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest() 
        {
        }
    }

    public class DbTest : IDisposable
    {
        private string dataBaseName = $"dbApiGameTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public DbTest()
        {
            // Connection MySql
            var connectionString =
                $"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=root";
            // var connectionString =
            //     "Persist Security Info=True;Server=(localdb)\\mssqllocaldb;Database={dataBaseName};Trusted_Connection=True;MultipleActiveResultSets=true;user=sa;password=sa@123456";

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o => 
                o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                ServiceLifetime.Transient
            );
            // serviceCollection.AddDbContext<MyContext>(o => 
            //     o.UseSqlServer(connectionString),
            //     ServiceLifetime.Transient
            // );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public ServiceProvider ServiceProvider { get; private set; }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
