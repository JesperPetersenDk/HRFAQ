using BlazorHrFaq.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorHrFaq.Database
{
    public class DatabaseDb : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Faq> Faq { get; set; }

        public DatabaseDb(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public DatabaseDb(DbContextOptions<DatabaseDb> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
