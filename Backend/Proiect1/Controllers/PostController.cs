using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using Proiect1.DAL;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostManager manager;

        public PostController(IPostManager postManager, AppDbContext context)
        {
            this.manager = postManager;
        }

        [HttpGet("GetAllUser{id}Posts")]
        public async Task<IActionResult> GetUserPosts([FromRoute] int id)
        {
            var posts = manager.GetAllUserPosts(id);

            return Ok(posts);
        }

        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAll()
        {
            var posts = manager.GetAllPosts();
            return Ok(posts);
        }


        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] PostModel postModel)
        {
            manager.CreatePost(postModel);
            return Ok();
        }

        [HttpPut("UpdatePostById")]
        public async Task<IActionResult> UpdatePost([FromBody] PostModel postModel)
        {
            manager.UpdatePost(postModel);
            return Ok();
        }

        [HttpDelete("DeletePostBy{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            manager.DeletePost(id);
            return Ok();
        }

        [HttpGet("Select-Posts-of-Friends(of-User{id})")]
        public async Task<IActionResult> GetPostsofFriends([FromRoute] int id)
        {
            var posts = manager.GetPostsofFriends(id);

            return Ok(posts);
        }

    }
}