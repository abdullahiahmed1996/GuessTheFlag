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


        [HttpGet("{id}")]
        public async Task<ActionResult<FlagModel>> Get(int id)
        {
            var flag = await _flagRepo.GetFlagById(id);
            if(flag == null)
            {
                return NotFound("Something went wrong!");
            }
            return Ok(flag);
        }

        [HttpGet]
        public async Task<ActionResult<List<FlagModel>>> GetAllFlags(int count)
        {
            var country = await _flagRepo.GetAllFlags(count);
            if(country == null)
            {
                return NotFound("Something went wrong!");
            }
            return Ok(country);
        }

        [HttpGet ("random/{count}")]
        public async Task<ActionResult<List<FlagModel>>> GetRandomFlags(int count)
        {
            var randomCountries = await _flagRepo.GetRandomFlags(count);
            if(randomCountries == null)
            {
                return NotFound("Something went wrong!");
            }
            return Ok(randomCountries);
        }




    }
}
