using GuessTheFlag.Server.Repositories;
using GuessTheFlag.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuessTheFlag.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;
        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo= countryRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetCountryById(int id)
        {
            var country = await _countryRepo.GetCountryById(id);
            if(country== null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        public async Task<ActionResult<List<CountryModel>>> GetAllCountries(int count)
        {
            var allCountries = await _countryRepo.GetAllCountries(count);
            if(allCountries==null)
            {
                return NotFound("OOPS! Something went wrong!");
            }
            return Ok(allCountries);
        }

        [HttpGet ("random/{count}")]
        public async Task<ActionResult<List<CountryModel>>> GetRandomCountries(int count)
        {
            var randomCountries = await _countryRepo.GetRandomCountries(count);
            if(randomCountries==null)
            {
                return NotFound("OOPS! Something went wrong!");
            }
            return Ok(randomCountries);
        }
    }
}
