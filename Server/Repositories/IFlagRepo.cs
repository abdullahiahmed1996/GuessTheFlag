using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface IFlagRepo
    {
            
        Task<List<CountryModel>> GetAllCountries();
        Task<CountryModel> GetCountryById(int id);
        Task<CountryModel> GetRandomCountries(int count);
        Task<CountryModel> UpdateCountry(CountryModel country);

    
    }
}
