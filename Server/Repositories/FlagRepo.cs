
using GuessTheFlag.Server.Data;
using GuessTheFlag.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheFlag.Server.Repositories
{
    public class FlagRepo : IFlagRepo
    {
        private readonly AppDbContext _context;
        public FlagRepo(AppDbContext context)
        {
            _context= context;
        }

        /// <summary>
        /// Hämtar alla flaggor upp till det angivna antalet i en lista.
        /// </summary>
        /// <param name="count">Antal flaggor att hämta.</param>
        /// <returns>En uppgift som representerar en lista av flaggmodeller.</returns>
        public async Task<List<FlagModel>> GetAllFlagsAsync(int count)
        {
            return await _context.Flags.Take(count).ToListAsync();
        }

        /// <summary>
        /// Hämtar en flagga med ett specifikt ID.
        /// </summary>
        /// <param name="id">ID för flaggan som ska hämtas.</param>
        /// <returns>En uppgift som representerar flaggmodellen med det angivna ID:et.</returns>
        public async Task<FlagModel> GetFlagByIdAsync(int id)
        {
            return await _context.Flags.FindAsync(id);
        }

        /// <summary>
        /// Hämtar ett angivet antal slumpmässiga flaggor i en lista.
        /// </summary>
        /// <param name="count">Antal slumpmässiga flaggor att hämta.</param>
        /// <returns>En uppgift som representerar en lista av slumpmässiga flaggmodeller.</returns>
        public async Task<List<FlagModel>> GetRandomFlagsAsync(int count)
        {
            return await _context.Flags.OrderBy(f => Guid.NewGuid()).Take(count).ToListAsync();
        }

        /// <summary>
        /// Uppdaterar en flagga i databasen.
        /// </summary>
        /// <param name="flag">Flaggmodell som ska uppdateras.</param>
        /// <returns>En uppgift som representerar den uppdaterade flaggmodellen.</returns>
        public async Task<FlagModel> UpdateFlagAsync(FlagModel flag)
        {
            _context.Flags.Update(flag);
            await _context.SaveChangesAsync();
            return flag;
        }
    }
}
