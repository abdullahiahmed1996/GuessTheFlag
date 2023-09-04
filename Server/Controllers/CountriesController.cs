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

        /// <summary>
        /// Hämtar ett land med ett specifikt ID.
        /// </summary>
        /// <param name="id">ID för landet som ska hämtas.</param>
        /// <returns>En uppgift som representerar landmodellen med det angivna ID:et.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetCountryByIdAsync(int id)
        {
            var country = await _countryRepo.GetCountryByIdAsync(id);
            if(country== null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        /// <summary>
        /// Hämtar ett land med ett specifikt namn.
        /// </summary>
        /// <param name="name">Namnet på landet som ska hämtas.</param>
        /// <returns>En uppgift som representerar landmodellen med det angivna namnet.</returns>
        [HttpGet ("name")]
        public async Task<ActionResult<CountryModel>> GetCountryByNameAsync(string name)
        {
            var countryName = await _countryRepo.GetCountryByNameAsync(name);
            if(countryName==null)
            {
                return NotFound("Sorry! We could not find the country you are looking for.");
            }
            return Ok(countryName);
        }

        /// <summary>
        /// Hämtar alla länder upp till det angivna antalet i en lista.
        /// </summary>
        /// <param name="count">Antal länder att hämta.</param>
        /// <returns>En uppgift som representerar en lista av landmodeller.</returns>
        [HttpGet]
        public async Task<ActionResult<List<CountryModel>>> GetAllCountriesAsync(int count)
        {
            var allCountries = await _countryRepo.GetAllCountriesAsync(count);
            if(allCountries==null)
            {
                return NotFound("OOPS! Something went wrong!");
            }
            return Ok(allCountries);
        }

        /// <summary>
        /// Hämtar ett angivet antal slumpmässiga länder i en lista.
        /// </summary>
        /// <param name="count">Antal slumpmässiga länder att hämta.</param>
        /// <returns>En uppgift som representerar en lista av slumpmässiga landmodeller.</returns>
        [HttpGet ("random/{count}")]
        public async Task<ActionResult<List<CountryModel>>> GetRandomCountriesAsync(int count)
        {
            var randomCountries = await _countryRepo.GetRandomCountriesAsync(count);
            if(randomCountries==null)
            {
                return NotFound("OOPS! Something went wrong!");
            }
            return Ok(randomCountries);
        }
    }
}
