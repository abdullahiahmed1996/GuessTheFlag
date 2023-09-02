using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Client.Services
{
    public interface ICountryService
    {
        Task<CountryModel> GetCountryByIdAsync(int id);
        Task<List<CountryModel>> GetAllCountriesAsync(int count);
        Task<CountryModel> GetCountryByNameAsync(string name);
        Task<List<CountryModel>> GetRandomCountriesAsync(int count);

    }
}
