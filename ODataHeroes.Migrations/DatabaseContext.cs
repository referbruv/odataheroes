using Microsoft.EntityFrameworkCore;
using ODataHeroes.Migrations.Entities;

namespace ODataHeroes.Migrations
{
    public class DatabaseContext : DbContext
    {
        private readonly DbContextOptions _options;

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
