using FilmaiOutAPI.Models;
using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Controllers
{
    [ApiController]
    [Route("FilmaiOut/[controller]")]
    public class MovieListsController : ControllerBase
    {
        private readonly MovieListsService _service;

        public MovieListsController(MovieListsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetLikedMovies()
        {
            var reviews = _service.GetMovieList();
            return new OkObjectResult(reviews);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            await _service.DeleteMovieList(id);

            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Post deletion was successful"
            });
        }
    }
}
