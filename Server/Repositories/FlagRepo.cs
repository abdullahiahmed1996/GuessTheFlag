﻿
using GuessTheFlag.Shared.Models;

namespace GuessTheFlag.Server.Repositories
{
    public class FlagRepo : IFlagRepo
    {
        public Task<List<CountryModel>> GetAllFlags(int count)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetFlagById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> GetRandomFlags(int count)
        {
            throw new NotImplementedException();
        }

        public Task<CountryModel> UpdateFlag(CountryModel flag)
        {
            throw new NotImplementedException();
        }
    }
}
