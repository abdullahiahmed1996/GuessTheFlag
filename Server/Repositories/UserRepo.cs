using GuessTheFlag.Server.Data;
using GuessTheFlag.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GuessTheFlag.Server.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserModel> _logger;
        public UserRepo(AppDbContext context, ILogger<UserModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Hämtar de bästa användarna baserat på poäng i en listform.
        /// </summary>
        /// <param name="count">Antal användare att hämta.</param>
        /// <returns>En uppgift som representerar en lista av användarmodeller.</returns>
        public async Task<List<UserModel>> GetTopScoresAsync(int count)
        {
            return await _context.Users.OrderByDescending(u => u.Score).Take(count).ToListAsync();
        }

        /// <summary>
        /// Spara en användares poäng i databasen.
        /// </summary>
        /// <param name="userScore">Användarmodell som innehåller poängen som ska sparas.</param>
        /// <returns>En uppgift som representerar den sparade användarmodellen med ett unikt ID.</returns>
        public async Task<int> SaveScoreAsync(UserModel userScore)
        {
            _context.Users.Add(userScore);
            await _context.SaveChangesAsync();
            return userScore.Id;
        }

       public async Task<UserModel> SaveUsernameAsync(string username)
        {
            try
            {
                var user = new UserModel { Username = username};

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }catch(Exception ex)
            {
               
                 _logger.LogError($"Could not save the username - Exception: {ex.Message}");
                throw;
            }
        }


    }
}
