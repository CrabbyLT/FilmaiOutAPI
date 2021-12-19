using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Mvc;
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
    }
}
