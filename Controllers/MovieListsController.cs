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
        public ActionResult ListMovieLists()
        {
            var reviews = _service.GetMovieList();
            return new OkObjectResult(reviews);
        }

        [HttpGet("movie/{id}")]
        public ActionResult GetMovie(string id)
        {
            return new OkObjectResult(_service.GetMovie(id));
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

        [HttpGet("{id:int}")]
        public ActionResult GetPersonalMovieList(int id)
        {
            var movieList = _service.GetPersonalMovieList(id);
            return movieList is not null
                ? new OkObjectResult(movieList)
                : new NotFoundObjectResult(new Response()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = $"No movie list is found based on {id}"
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
