using GuessTheFlag.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheFlag.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryModel>().HasData(
                new CountryModel()
                {
                    Id = 1,
                    Name = "Afghanistan",
                    Flag = "Afghanistan.gif"
                },
                 new CountryModel()
                 {
                     Id = 2,
                     Name = "Albania",
                     Flag = "Albania.gif"
                 }
                );
        }
    }
}
