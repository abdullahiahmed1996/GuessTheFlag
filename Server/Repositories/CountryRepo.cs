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

        /// <summary>
        /// Hämtar alla länder upp till det angivna antalet i en lista.
        /// </summary>
        /// <param name="count">Antal länder att hämta.</param>
        /// <returns>En uppgift som representerar en lista av landmodeller.</returns>
        public async Task<List<CountryModel>> GetAllCountriesAsync(int count)
        {
            return await _context.Countries.Take(count).ToListAsync();
        }

        /// <summary>
        /// Hämtar ett land med ett specifikt ID.
        /// </summary>
        /// <param name="id">ID för landet som ska hämtas.</param>
        /// <returns>En uppgift som representerar landmodellen med det angivna ID:et.</returns>
        public async Task<CountryModel> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        /// <summary>
        /// Hämtar ett land med ett specifikt namn.
        /// </summary>
        /// <param name="name">Namnet på landet som ska hämtas.</param>
        /// <returns>En uppgift som representerar landmodellen med det angivna namnet.</returns>
        public async Task<CountryModel> GetCountryByNameAsync(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Name == name);
        }

        /// <summary>
        /// Hämtar ett angivet antal slumpmässiga länder i en lista.
        /// </summary>
        /// <param name="count">Antal slumpmässiga länder att hämta.</param>
        /// <returns>En uppgift som representerar en lista av slumpmässiga landmodeller.</returns>
        public async Task<List<CountryModel>> GetRandomCountriesAsync(int count)
        {
            return await _context.Countries.OrderBy(c => Guid.NewGuid()).Take(count).ToListAsync();
        }
    }
}
