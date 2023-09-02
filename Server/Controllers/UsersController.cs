using GuessTheFlag.Server.Repositories;
using GuessTheFlag.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessTheFlag.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo)
        {
            _userRepo= userRepo;
        }

        /// <summary>
        /// Hämtar de bästa användarna baserat på poäng i en listform.
        /// </summary>
        /// <param name="count">Antal användare att hämta.</param>
        /// <returns>En uppgift som representerar en lista av användarmodeller.</returns>
        [HttpGet ("topscores/{count}")]
        public async Task<ActionResult<List<UserModel>>> GetTopScoresAsync(int count)
        {
            var topScores = await _userRepo.GetTopScoresAsync(count);
            if(topScores == null)
            {
                return NotFound ("OOPS! The Leader Board might be empty.");
            }
            return Ok (topScores);
        }

        /// <summary>
        /// Spara en användares poäng i databasen.
        /// </summary>
        /// <param name="userScore">Användarmodell som innehåller poängen som ska sparas.</param>
        /// <returns>En uppgift som representerar det sparade användar-ID:et.</returns>
        [HttpPost ("save")]
        public async Task<ActionResult<int>> SaveScoreAsync(UserModel userScore)
        {
            var saveScore = await _userRepo.SaveScoreAsync(userScore);
            if(saveScore == null)
            {
                return BadRequest("Something went wrong! The score is not saved.");
            }
            return Ok (saveScore);
        }

    }
}
