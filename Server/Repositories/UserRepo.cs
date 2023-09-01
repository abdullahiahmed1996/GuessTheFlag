using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public class UserRepo : IUserRepo
    {
        public Task<List<UserModel>> GetTopScores(int count)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveScore(UserModel userScore)
        {
            throw new NotImplementedException();
        }
    }
}
