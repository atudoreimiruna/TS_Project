using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proiect1.BLL.DTOs;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBookManager manager;

        public BookController(IBookManager bookManager, IHttpClientFactory httpClientFactory)
        {
            this.manager = bookManager;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            manager.AddBook(bookModel);
            return Ok();
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = manager.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("GetBookBy{title}")]
        public async Task<IActionResult> GetBook([FromRoute] string title)
        {
            var book = manager.GetBook(title);
            return Ok(book);
        }

        [HttpGet("GetBookRecommendations")]
        public async Task<IActionResult> GetBookRecommendations()
        {
            var books = manager.GetBookRecommendations();
            return Ok(books);
        }

        [HttpPost("get-summary")]
        public async Task<IActionResult> GetSummary([FromBody] BookRequest request)
        {
            var requestUrl = "http://localhost:5000/api/summary";
            var json = JsonConvert.SerializeObject(new { title = request.Title });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "api-key");
            var response = await client.PostAsync(requestUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error calling Flask API");
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);
            return Ok(new { responseObject.summary });
        }
    }
}
