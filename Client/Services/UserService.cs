using GuessTheFlag.Shared.Models;
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
                // Anropa API för att hämta bestämda antal top poäng
                var response = await _httpClient.GetFromJsonAsync<List<UserModel>>($"api/users/topscores/{count}");

                if(response != null)
                {
                    return response;
                }else
                {
                    _logger.LogError("No top scores found!");
                    return new List<UserModel>();
                }
            }catch(HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogWarning($"No top scores found: {ex.Message}");
                return new List<UserModel>();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogWarning($"Error: {ex.StatusCode} - {ex.Message}");
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
                    throw new Exception($"Could not save your score. Status Code: {response.StatusCode}, Error: {errorMessage} ");

                }

            }catch(Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                return 500;
            }
        }

        public async Task<UserModel> SaveUsernameAsync(string username)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/users/save", username);

                if (response.IsSuccessStatusCode)
                {
                    var savedUser = await response.Content.ReadFromJsonAsync<UserModel>();
                    return savedUser;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"HTTP request error: {response.StatusCode} - {errorMessage}");
                    throw new Exception(errorMessage);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"HTTP request error: {ex.StatusCode} - {ex.Message}");
                throw new Exception("An error occurred while saving the username.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
