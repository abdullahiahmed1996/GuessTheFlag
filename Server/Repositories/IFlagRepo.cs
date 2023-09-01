using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IFlagRepo
    {
            
        Task<List<CountryModel>> GetAllFlags(int count);
        Task<CountryModel> GetFlagById(int id);
        Task<CountryModel> GetRandomFlags(int count);
        Task<CountryModel> UpdateFlag(CountryModel flag);

    
    }
}
