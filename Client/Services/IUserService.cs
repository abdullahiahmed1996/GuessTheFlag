using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Client.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetTopScoresAsync(int count);
        Task<int> SaveScoreAsync(UserModel userScore);
        Task<UserModel> SaveUsernameAsync(string userName);
    }
}
