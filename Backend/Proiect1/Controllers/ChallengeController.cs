using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/Challenges")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallManager manager;

        public ChallengeController(IChallManager challManager)
        {
            this.manager = challManager;
        }

        [HttpGet("GetAllChallenges")]
        public async Task<IActionResult> GetChallenges()
        {
            var challenges = manager.GetChallenges();
            return Ok(challenges);
        }

        [HttpGet("GetNewestChallenge")]
        public async Task<IActionResult> GetNewestChallenge()
        {
            var newestChall = manager.GetNewestChallenge();
            return Ok(newestChall);
        }

        [HttpPost("CreateChallenge")]
        public async Task<IActionResult> CreateChallenge([FromBody] ChallengeModel challengeModel)
        {
            manager.CreateChallenge(challengeModel);
            return Ok();
        }

        [HttpPut("UpdateChallengeById")]
        public async Task<IActionResult> UpdateChallenge([FromBody] ChallengeModel challengeModel)
        {
            manager.UpdateChallenge(challengeModel);
            return Ok();
        }

        [HttpDelete("DeleteChallengeBy{id}")]
        public async Task<IActionResult> DeleteChallenge([FromRoute] int id)
        {
            manager.DeleteChallenge(id);
            return Ok();
        }
    }
}