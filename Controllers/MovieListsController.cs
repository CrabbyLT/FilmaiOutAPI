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

        [HttpGet("reviews")]
        public ActionResult GetLikedMovies()
        {
            var reviews = _service.GetMovieList();
            return new OkObjectResult(reviews);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMovieAsync(int id)
        {
            await _service.DeleteMovieList(id);

            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Movie list deletion was successful"
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovieListAsync([FromBody] MovieListModel subtitleListModel)
        {
            await _service.CreateMovieList(subtitleListModel);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Movie list created successfully"
            });
        }
        
        [HttpPost("{id:int}")]
        public async Task<ActionResult> UpdateMovieListAsync(string name, string description, int id)
        {
            await _service.UpdateMovieList(name, description, id);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Movie list updated successfully"
            });
        }

        [HttpPost("{movieListId:int}/movie/{movieImdbId}")]
        public async Task<ActionResult> AddMovieToMovieList(int movieListId, string movieImdbId)
        {
            await _service.AddMovieToMovieList(movieListId, movieImdbId);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Movie inserted successfully"
            }) ;
        }
    }
}
