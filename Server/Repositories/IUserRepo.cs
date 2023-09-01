using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IUserRepo
    {
        Task<int> SaveScore(UserModel userScore);
        Task<List<UserModel>> GetTopScores(int count);
    }
}