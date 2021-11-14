using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataHeroes.Contracts.Data.Repositories;
using ODataHeroes.Migrations;
using ODataHeroes.Migrations.Entities;
using System.Linq;

namespace ODataHeroes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            using (var sp = builder.Services.CreateScope())
            {
                var db = sp.ServiceProvider.GetRequiredService<DatabaseContext>();

                if (db.Database.GetPendingMigrations().Count() > 0)
                {
                    db.Database.Migrate();
                }

                var unitOfWork = sp.ServiceProvider.GetRequiredService<IUnitOfWork>();

                if (unitOfWork.Heroes.Count() == 0)
                {
                    for (int i = 1; i <= 1000; i++)
                    {
                        unitOfWork.Heroes.Add(new Hero
                        {
                            Name = $"Hero #{1000 + i}",
                            Description = $"Saikyo no Hero #{1000 + i}",
                        });
                    }
                    unitOfWork.Commit();
                }
            }

            builder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
