using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IFlagRepo
    {
            
        Task<List<FlagModel>> GetAllFlagsAsync(int count);
        Task<FlagModel> GetFlagByIdAsync(int id);
        Task<List<FlagModel>> GetRandomFlagsAsync(int count);
        Task<FlagModel> UpdateFlagAsync(FlagModel flag);

    
    }
}
