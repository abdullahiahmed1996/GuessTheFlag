using GuessTheFlag.Server.Repositories;
using GuessTheFlag.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuessTheFlag.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlagsController : ControllerBase
    {
        private readonly IFlagRepo _flagRepo;
        public FlagsController(IFlagRepo flagRepo)
        {
            _flagRepo= flagRepo;
        }

        /// <summary>
        /// Hämtar en flagga med ett specifikt ID.
        /// </summary>
        /// <param name="id">ID för flaggan som ska hämtas.</param>
        /// <returns>En uppgift som representerar flaggmodellen med det angivna ID:et.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FlagModel>> GetFlagByIdAsync(int id)
        {
            var flag = await _flagRepo.GetFlagByIdAsync(id);
            if(flag == null)
            {
                return NotFound("Something went wrong!");
            }
            return Ok(flag);
        }

        /// <summary>
        /// Hämtar alla flaggor upp till det angivna antalet i en lista.
        /// </summary>
        /// <param name="count">Antal flaggor att hämta.</param>
        /// <returns>En uppgift som representerar en lista av flaggmodeller.</returns>
        [HttpGet]
        public async Task<ActionResult<List<FlagModel>>> GetAllFlagsAsync(int count)
        {
            var country = await _flagRepo.GetAllFlagsAsync(count);
            if(country == null)
            {
                return NotFound("Something went wrong!");
            }
            return Ok(country);
        }

        /// <summary>
        /// Hämtar en slumpmässig flagga.
        /// </summary>
        /// <returns>En uppgift som representerar en slumpmässig FlagModel.</returns>
        [HttpGet("random")]
        public async Task<ActionResult<FlagModel>> GetRandomFlagAsync()
        {
            var randomFlag = await _flagRepo.GetRandomFlagAsync();
            if (randomFlag == null)
            {
                return NotFound("No flags found!");
            }
            return Ok(randomFlag);
        }
    }
}
