using FilmaiOutAPI.Models;
using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Controllers
{
    [ApiController]
    [Route("FilmaiOut/[controller]")]
    public class MovieReviewsController : ControllerBase
    {
        private readonly MovieReviewsService _service;

        public MovieReviewsController(MovieReviewsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetMovieReviews()
        {
            var reviews = _service.GetReviews();
            return new OkObjectResult(reviews);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            await _service.DeleteMovieReview(id);

            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Post deletion was successful"
            });
        }
    }
}
