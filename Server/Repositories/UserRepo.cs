using GuessTheFlag.Server.Data;
using GuessTheFlag.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheFlag.Server.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetTopScores(int count)
        {
            return await _context.Users.OrderByDescending(u => u.Score).Take(count).ToListAsync();
        }

        public async Task<int> SaveScore(UserModel userScore)
        {
            _context.Users.Add(userScore);
            await _context.SaveChangesAsync();
            return userScore.Id;
        }
    }
}
