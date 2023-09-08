using GuessTheFlag.Shared.Models;
using System.Net.Http.Json;

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
                var response = await _httpClient.GetFromJsonAsync<List<CountryModel>>($"api/countries/{count}");

                if(response != null)
                {
                    return response;
                }
                else
                {
                    var errorMessage = "Countries not found!";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }

            }catch(HttpRequestException ex)
            {
                var errorMessage = $"HTTP request error: {ex.StatusCode} - {ex.Message}";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
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
                var response = await _httpClient.GetFromJsonAsync<CountryModel>($"api/countries/{id}");

                if(response != null )
                {
                    return response;
                }
                else
                {
                    var errorMessage = "Country not found!";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }

            }catch(HttpRequestException ex)
            {
                var errorMessage = $"HTTP request error: {ex.StatusCode} - {ex.Message}";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
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
                var response = await _httpClient.GetFromJsonAsync<CountryModel>($"api/countries/{name}");

                if (response != null)
                {
                    return response;
                }
                else
                {
                    var errorMessage = "Country not found!";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }

            }
            catch (HttpRequestException ex)
            {
                var errorMessage = $"HTTP request error: {ex.StatusCode} - {ex.Message}";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
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
                var response = await _httpClient.GetFromJsonAsync<List<CountryModel>>($"api/countries/random/{count}");

                if (response != null)
                {
                    return response;
                }
                else
                {
                    var errorMessage = "Countries not found!";
                    _logger.LogError(errorMessage);
                    throw new Exception(errorMessage);
                }

            }
            catch (HttpRequestException ex)
            {
                var errorMessage = $"HTTP request error: {ex.StatusCode} - {ex.Message}";
                _logger.LogError(errorMessage);
                throw new Exception(errorMessage);
            }
        }
    }
}
