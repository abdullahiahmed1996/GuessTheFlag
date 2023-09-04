using GuessTheFlag.Shared.Models;
using System.Net.Http.Json;

namespace GuessTheFlag.Client.Services
{
    public class FlagService : IFlagService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FlagService> _logger;

        public FlagService(ILogger<FlagService> logger, HttpClient httpClient)
        {
            _httpClient= httpClient;
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
                var response = await _httpClient.GetFromJsonAsync<List<FlagModel>>($"api/flags/{count}");
                
                if(response != null)
                {
                    return response;
                }
                else
                {
                    var errorMessage = "No flags found!";
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
        /// Hämtar en flagga med ett specifikt ID från API:et.
        /// </summary>
        /// <param name="id">ID för flaggan som ska hämtas.</param>
        /// <returns>En uppgift som representerar FlagModel-objektet med det angivna ID:et.</returns>
        public async Task<FlagModel> GetFlagByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<FlagModel>($"api/flags/{id}");

                if (response != null)
                {
                    return response;
                }
                else
                {
                    var errorMessage = "The flag was not found!";
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
        /// Hämtar ett angivet antal slumpmässiga flaggor från API:et.
        /// </summary>
        /// <param name="count">Antal slumpmässiga flaggor att hämta.</param>
        /// <returns>En uppgift som representerar en lista av slumpmässiga FlagModel-objekt.</returns>
        public async Task<List<FlagModel>> GetRandomFlagsAsync(int count)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<FlagModel>>($"api/flags/random/{count}");

                if (response != null)
                {
                    return response;
                }
                else
                {
                    var errorMessage = "Random flags were not found!";
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
    }
}
