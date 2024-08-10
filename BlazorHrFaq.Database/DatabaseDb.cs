using BlazorHrFaq.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorHrFaq.Database
{
    public class DatabaseDb : DbContext
    {
        public DbSet<Faq> Faq { get; set; }

        public DatabaseDb()
        {

        }

        public DatabaseDb(DbContextOptions<DatabaseDb> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=hrfaq;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
