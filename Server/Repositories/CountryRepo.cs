using GuessTheFlag.Server.Data;
using GuessTheFlag.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheFlag.Server.Repositories
{
    public class CountryRepo : ICountryRepo
    {
        private readonly AppDbContext _context;
        public CountryRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<CountryModel>> GetAllCountries(int count)
        {
            return await _context.Countries.Take(count).ToListAsync();
        }

        public async Task<CountryModel> GetCountryById(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<CountryModel> GetCountryByName(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name = name);
        }

        public async Task<List<CountryModel>> GetRandomCountries(int count)
        {
            return await _context.Countries.OrderBy(c => Guid.NewGuid()).Take(count).ToListAsync();
        }
    }
}
