using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ODataCore3.API.Models;

namespace ODataCore3.API.Providers
{
    public class ReadersContext : DbContext
    {
        public DbSet<Reader> Readers { get; set; }
        public DbSet<User> Users { get; set; }

        public ReadersContext(DbContextOptions<ReadersContext> options) : base(options)
        {
        }
    }
}