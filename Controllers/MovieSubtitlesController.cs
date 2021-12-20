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
        public ActionResult GetSubtitles()
        {
            var reviews = _service.GetSubtitles();
            return new OkObjectResult(reviews);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSubtitlesAsync(int id)
        {
            await _service.DeleteSubtitleList(id);

            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Subtitile deletion was successful"
            });
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubtitileListCommentAsync([FromBody] SubtitleListModel subtitleListModel)
        {
            await _service.CreateSubtitleAsync(subtitleListModel);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Subtitle list created successfully"
            });
        }

        [HttpPost("{id:int}")]
        public async Task<ActionResult> UpdateSubtitileListCommentAsync([FromQuery] string language,int id)
        {
            await _service.UpdateSubtitleAsync(language,id);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Subtitle list updated successfully"
            });
        }
    }
}
