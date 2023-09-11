using GuessTheFlag.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace GuessTheFlag.Client.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CountryService> _logger;

        public CountryService(HttpClient httpClient, ILogger<CountryService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Hämtar alla länder från API:et upp till det angivna antalet.
        /// </summary>
        /// <param name="count">Antal länder att hämta.</param>
        /// <returns>En uppgift som representerar en lista av CountryModel-objekt.</returns>
        public async Task<List<CountryModel>> GetAllCountriesAsync(int count)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/countries/{count}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var countries = JsonConvert.DeserializeObject<List<CountryModel>>(json);
                    return countries;
                }
                else
                {
                    var errorMessage = $"HTTP request error: {response.StatusCode} - {response.ReasonPhrase}";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Hämtar ett land med ett specifikt ID från API:et.
        /// </summary>
        /// <param name="id">ID för landet som ska hämtas.</param>
        /// <returns>En uppgift som representerar CountryModel-objektet med det angivna ID:et.</returns>
        public async Task<CountryModel> GetCountryByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/countries/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var country = JsonConvert.DeserializeObject<CountryModel>(json);
                    return country;
                }
                else
                {
                    var errorMessage = $"HTTP request error: {response.StatusCode} - {response.ReasonPhrase}";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Hämtar ett land med ett specifikt namn från API:et.
        /// </summary>
        /// <param name="name">Namnet på landet som ska hämtas.</param>
        /// <returns>En uppgift som representerar CountryModel-objektet med det angivna namnet.</returns>
        public async Task<CountryModel> GetCountryByNameAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/countries/{name}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var country = JsonConvert.DeserializeObject<CountryModel>(json);
                    return country;
                }
                else
                {
                    var errorMessage = $"HTTP request error: {response.StatusCode} - {response.ReasonPhrase}";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Hämtar ett angivet antal slumpmässiga länder från API:et.
        /// </summary>
        /// <param name="count">Antal slumpmässiga länder att hämta.</param>
        /// <returns>En uppgift som representerar en lista av slumpmässiga CountryModel-objekt.</returns>
        public async Task<List<CountryModel>> GetRandomCountriesAsync(int count)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/countries/random/{count}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var countries = JsonConvert.DeserializeObject<List<CountryModel>>(json);
                    var random = new Random();
                    var randomCountries = countries.OrderBy(c => random.Next()).Take(count).ToList();

                    return randomCountries;
                }
                else
                {
                    var errorMessage = $"HTTP request error: {response.StatusCode} - {response.ReasonPhrase}";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw ex;
            }
        }
    }
}
