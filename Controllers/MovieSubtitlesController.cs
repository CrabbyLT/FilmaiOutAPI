using FilmaiOutAPI.Models;
using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Controllers
{
    [ApiController]
    [Route("FilmaiOut/[controller]")]
    public class MovieSubtitlesController : ControllerBase
    {
        private readonly MovieSubtitlesService _service;

        public MovieSubtitlesController(MovieSubtitlesService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetLikedMovies()
        {
            var reviews = _service.GetSubtitles();
            return new OkObjectResult(reviews);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            await _service.DeleteSubtitleList(id);

            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Post deletion was successful"
            });
        }
    }
}
