using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface ICountryRepo
    {

        Task<CountryModel> GetCountryById(int id);
        Task<CountryModel> GetCountryByName(string name);
        Task<List<CountryModel>> GetAllCountries(int count);
        Task<CountryModel> GetRandomCountries(int count);
    }
}
