
using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public class FlagRepo : IFlagRepo
    {
        public Task<List<CountryModel>> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetCountryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetRandomCountries(int count)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> UpdateCountry(CountryModel country)
        {
            throw new NotImplementedException();
        }
    }
}
