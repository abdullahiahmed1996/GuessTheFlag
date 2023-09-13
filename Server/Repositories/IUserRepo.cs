using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IUserRepo
    {
        Task<int> SaveScoreAsync(UserModel userScore);
        Task<List<UserModel>> GetTopScoresAsync(int count);

        Task<UserModel> SaveUsernameAsync(string username);
        Task<UserModel?> GetByUsernameAsync(string username);
    }
}