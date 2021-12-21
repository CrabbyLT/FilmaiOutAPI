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

        [HttpPost]
        public async Task<ActionResult> CreateMovieListAsync([FromBody] MovieReviewModel movieReviewModel)
        {
            await _service.CreateReviewAsync(movieReviewModel);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Movie review created successfully"
            });
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult> UpdateMovieReviewAsync([FromBody] MovieReviewModel movieReviewModel, int id)
        {
            await _service.UpdateReviewAsync(movieReviewModel, id);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Movie list updated successfully"
            });
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
