using GuessTheFlag.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GuessTheFlag.Client.Services
{
    public class FlagService : IFlagService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FlagService> _logger;

        public FlagService(ILogger<FlagService> logger, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Hämtar alla flaggor från API:et upp till det angivna antalet.
        /// </summary>
        /// <param name="count">Antal flaggor att hämta.</param>
        /// <returns>En uppgift som representerar en lista av FlagModel-objekt.</returns>
        public async Task<List<FlagModel>> GetAllFlagsAsync(int count)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/flags/{count}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var flags = JsonConvert.DeserializeObject<List<FlagModel>>(json);
                    return flags;
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
        /// Hämtar en flagga med ett specifikt ID från API:et.
        /// </summary>
        /// <param name="id">ID för flaggan som ska hämtas.</param>
        /// <returns>En uppgift som representerar FlagModel-objektet med det angivna ID:et.</returns>
        public async Task<FlagModel> GetFlagByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/flags/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var flag = JsonConvert.DeserializeObject<FlagModel>(json);
                    return flag;
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
        /// Hämtar en slumpmässig flagga från API:et.
        /// </summary>
        /// <returns>En uppgift som representerar en slumpmässig FlagModel-objekt.</returns>
        public async Task<FlagModel> GetRandomFlagAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/flags/random");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var flag = JsonConvert.DeserializeObject<FlagModel>(json);
                    return flag;
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
