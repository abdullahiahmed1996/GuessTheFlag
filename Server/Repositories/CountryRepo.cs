using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public class CountryRepo : ICountryRepo
    {
        public Task<List<CountryModel>> GetAllCountries(int count)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetCountryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetCountryByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetRandomCountries(int count)
        {
            throw new NotImplementedException();
        }
    }
}
