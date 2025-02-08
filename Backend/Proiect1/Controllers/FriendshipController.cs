using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/Friendships")]
    [ApiController]
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendshipManager manager;
        public FriendshipController(IFriendshipManager friendshipManager)
        {
            this.manager = friendshipManager;
        }

        [HttpPost("CreateFriendship")]
        public async Task<IActionResult> AddFriendship([FromBody] FriendshipModel friendshipModel)
        {
            manager.AddFriendship(friendshipModel);
            return Ok();
        }

        [HttpGet("GetAllFriendships")]
        public async Task<IActionResult> GetAllFriendships()
        {
            var friendships = manager.GetAllFriendships();
            return Ok(friendships);
        }

        [HttpDelete("DeleteFriendshipBy{id}")]
        public async Task<IActionResult> DeleteFriendship([FromRoute] int id)
        {
            manager.DeleteFriendship(id);
            return Ok();
        }
    }
}