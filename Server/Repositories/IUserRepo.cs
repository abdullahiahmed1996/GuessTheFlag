﻿using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IUserRepo
    {
        Task<int> SaveScoreAsync(UserModel userScore);
        Task<List<UserModel>> GetTopScoresAsync(int count);
    }
}