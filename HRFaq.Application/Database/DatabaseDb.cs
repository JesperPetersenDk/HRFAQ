using BlazorHrFaq.Database.Model;
using HrFaq.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorHrFaq.Database
{
    public class DatabaseDb : DbContext
    {
        public DbSet<Faq> Faq { get; set; }
        public DbSet<MatchData> Match { get; set; }
        public DbSet<SettingInfo> SettingInfo { get; set; }
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

            modelBuilder.Entity<MatchData>().HasKey(r => r.MatchId);

            modelBuilder.Entity<Faq>().HasKey(r => r.FaqId);


            modelBuilder.Entity<SettingInfo>().HasKey(r => r.SettingInfoId);

            modelBuilder.Entity<Faq>()
                .HasData(
                    new Faq
                    {
                        HitCount = 1,
                        Answer = "Hello world",
                        SearchWords = "Hej",
                    },
                    new Faq
                    {
                        HitCount = 1,
                        Answer = "Hello world",
                        SearchWords = "Jesper",
                    },
                    new Faq
                    {
                        HitCount = 1,
                        Answer = "Hello world",
                        SearchWords = "Test",
                    }
                );
            modelBuilder.Entity<SettingInfo>()
                .HasData(
                    new SettingInfo
                    {
                        AnswerMuli = true,
                        RemoveMatchWords = false,
                        StatusRapport = true,
                        CompanyCategory = false,
                        LoginUser = false,
                        LinkTarget = true
                    }
                );
        }
    }
}
