using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
