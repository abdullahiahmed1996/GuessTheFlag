using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IFlagRepo
    {
            
        Task<List<FlagModel>> GetAllFlags(int count);
        Task<FlagModel> GetFlagById(int id);
        Task<FlagModel> GetRandomFlags(int count);
        Task<FlagModel> UpdateFlag(FlagModel flag);

    
    }
}
