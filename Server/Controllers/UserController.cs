using GuessTheFlag.Server.Repositories;
using GuessTheFlag.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuessTheFlag.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo= userRepo;
        }

        [HttpGet ("topscores/{count}")]
        public async Task<ActionResult<List<UserModel>>> GetTopScores(int count)
        {
            var topScores = await _userRepo.GetTopScores (count);
            if(topScores == null)
            {
                return NotFound ("OOPS! The Leader Board might be empty.");
            }
            return Ok (topScores);
        }

        [HttpPost ("save")]
        public async Task<ActionResult<int>> SaveScore(UserModel userScore)
        {
            var saveScore = await _userRepo.SaveScore (userScore);
            if(saveScore == null)
            {
                return BadRequest ("Something went wrong! The score is not saved.")
            }
            return Ok (saveScore);
        }

    }
}
