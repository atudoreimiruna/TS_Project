using Microsoft.AspNetCore.Mvc;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewManager manager;
        public ReviewController(IReviewManager reviewManager)
        {
            this.manager = reviewManager;
        }

        //get all reviews
        [HttpGet("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = manager.GetAllReviews();
            return Ok(reviews);
        }

        // get the reviews made by a specific user
        [HttpGet("GetReviewsByUser/{id}")]
        public async Task<IActionResult> GetUserReviews([FromRoute] int id)
        {

            var userReviews = manager.GetUserReviews(id);

            return Ok(userReviews);

        }

        //get all the reviews for a specific book
        [HttpGet("GetReviewsByBookname/{bookName}")]
        public async Task<IActionResult> GetBookReviews([FromRoute] string bookName)
        {

            var bookReviews = manager.GetBookReviews(bookName);

            return Ok(bookReviews);

        }

        //make a review (user)
        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview([FromBody] ReviewModel reviewModel)
        {

            manager.CreateReview(reviewModel);
            return Ok();
        }

        //edit a review with a given id (user)
        [HttpPut("UpdateReviewBy{id}")]
        public async Task<IActionResult> UpdateChallenge([FromBody] ReviewModel reviewModel)
        {
            manager.UpdateReview(reviewModel);
            return Ok();
        }

        //delete a review with a given id (user)
        [HttpDelete("DeleteReviewBy{id}User")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            manager.DeleteReview(id);
            return Ok();
        }

        //delete a review with a given id (admin)
        [HttpDelete("DeleteReviewBy{id}Admin")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteReviewAdmin([FromRoute] int id)
        {
            manager.DeleteReview(id);
            return Ok();
        }

        [HttpGet("GetReviewsofUser's{id}Friends")]
        public async Task<IActionResult> GetReviewsofFriends([FromRoute] int id)
        {
            var reviews = manager.GetReviewsofFriends(id);

            return Ok(reviews);
        }
    }
}