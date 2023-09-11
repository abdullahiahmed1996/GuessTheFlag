using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Client.Services
{
    public interface IFlagService
    {
        Task<FlagModel> GetFlagByIdAsync(int id);
        Task<List<FlagModel>> GetAllFlagsAsync(int count);
        Task<FlagModel> GetRandomFlagAsync();
    }
}
