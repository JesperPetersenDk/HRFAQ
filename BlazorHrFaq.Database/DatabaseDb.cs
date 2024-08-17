using BlazorHrFaq.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorHrFaq.Database
{
    public class DatabaseDb : DbContext
    {
        public DbSet<Faq> Faq { get; set; }
        public DatabaseDb(DbContextOptions<DatabaseDb> options) : base(options)
        {

        }

        public DatabaseDb()
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

            modelBuilder.Entity<Faq>().HasKey(r => r.FaqId);

            modelBuilder.Entity<Faq>()
                .HasData(
                    new Faq
                    {
                        HitCount = 1,
                        Answer = "Hello world",
                        SearchWords = "Hej",
                        LastUpdate = DateTime.Now,
                        Priority = PriorityEnum.Lowest,
                    },
                    new Faq
                    {
                        HitCount = 1,
                        Answer = "Hello world",
                        SearchWords = "Jesper",
                        LastUpdate = DateTime.Now,
                        Priority = PriorityEnum.Lowest,
                    },
                    new Faq
                    {
                        HitCount = 1,
                        Answer = "Hello world",
                        SearchWords = "Test",
                        LastUpdate = DateTime.Now,
                        Priority = PriorityEnum.Lowest,
                    }
                );
        }
    }
}
