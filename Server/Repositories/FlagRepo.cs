
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
        public async Task<List<FlagModel>> GetAllFlags(int count)
        {
            return await _context.Flags.Take(count).ToListAsync();
        }

        public async Task<FlagModel> GetFlagById(int id)
        {
            return await _context.Flags.FindAsync(id);
        }

        public async Task<List<FlagModel>> GetRandomFlags(int count)
        {
            return await _context.Flags.OrderBy(f => Guid.NewGuid()).Take(count).ToListAsync();
        }

        public async Task<FlagModel> UpdateFlag(FlagModel flag)
        {
            _context.Flags.Update(flag);
            await _context.SaveChangesAsync();
            return flag;
        }

    }
}
