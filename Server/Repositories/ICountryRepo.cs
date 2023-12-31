﻿using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public interface ICountryRepo
    {

        Task<CountryModel> GetCountryByIdAsync(int id);
        Task<CountryModel> GetCountryByNameAsync(string name);
        Task<List<CountryModel>> GetAllCountriesAsync(int count);
        Task<List<CountryModel>> GetRandomCountriesAsync(int count);
    }
}
