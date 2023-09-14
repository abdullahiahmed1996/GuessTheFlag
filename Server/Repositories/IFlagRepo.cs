using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IFlagRepo
    {
            
        Task<List<FlagModel>> GetAllFlagsAsync(int count);
        Task<FlagModel> GetFlagByIdAsync(int id);
        Task<FlagModel> GetRandomFlagAsync();
        Task<FlagModel> UpdateFlagAsync(FlagModel flag);

    
    }
}
