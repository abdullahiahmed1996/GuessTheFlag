
using GuessTheFlag.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheFlag.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<FlagModel> Flags { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel { Id = 1, Name = "Afghanistan" },
                new CountryModel { Id = 2, Name = "Albania" }
                );

            modelBuilder.Entity<FlagModel>().HasData(
                new FlagModel { Id = 1, ImgUrl = "Afghanistan.gif", CountryId = 1 },
                new FlagModel { Id = 2, ImgUrl = "Albania.gif", CountryId = 2 }
                );
        }
    }
}
