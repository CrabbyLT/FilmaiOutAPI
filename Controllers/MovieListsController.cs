using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
