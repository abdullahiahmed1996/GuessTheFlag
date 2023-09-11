using GuessTheFlag.Shared.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace GuessTheFlag.Client.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserService> _logger;

        public UserService(HttpClient httpClient, ILogger<UserService> logger)
        {
            _httpClient= httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Hämtar en lista med de högsta poängen från API:et.
        /// </summary>
        /// <param name="count">Antal högsta poäng att hämta.</param>
        /// <returns>En uppgift som representerar en lista av UserModel-objekt.</returns>
        public async Task<List<UserModel>> GetTopScoresAsync(int count)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/users/topscores/{count}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var topScores = JsonConvert.DeserializeObject<List<UserModel>>(json);
                    return topScores;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    _logger.LogWarning("No top scores found.");
                    return new List<UserModel>();
                }
                else
                {
                    var errorMessage = $"HTTP request error: {response.StatusCode} - {response.ReasonPhrase}";
                    _logger.LogWarning(errorMessage);
                    return new List<UserModel>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                return new List<UserModel>();
            }
        }

        /// <summary>
        /// Sparar en användares poäng i API:et.
        /// </summary>
        /// <param name="userScore">Användarmodell som innehåller poängen som ska sparas.</param>
        /// <returns>En uppgift som representerar det sparade användar-ID:et.</returns>
        public async Task<int> SaveScoreAsync(UserModel userScore)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/users/save", userScore);

                if (response.IsSuccessStatusCode)
                {
                    var savedScore = await response.Content.ReadFromJsonAsync<int>();
                    return savedScore;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Could not save your score. Status Code: {response.StatusCode}, Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return 500;
            }
        }
        public async Task<int> SaveUsernameAsync(string username)
        {
            try
            {
                var user = new UserModel
                {
                    Username = username
                };

                var response = await _httpClient.PostAsJsonAsync("api/users/saveusername", user);

                if (response.IsSuccessStatusCode)
                {
                    var savedUserId = await response.Content.ReadFromJsonAsync<int>();
                    return savedUserId;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Could not save the username. Status Code: {response.StatusCode}, Error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return 500; // You can handle errors as needed
            }
        }
    }
}
