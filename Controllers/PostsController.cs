using FilmaiOutAPI.Models;
using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Controllers
{
    [ApiController]
    [Route("FilmaiOut/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostsService _service;

        public PostsController(PostsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetPosts()
        {
            var posts = _service.GetPosts();
            return new OkObjectResult(posts);
        }

        [HttpGet("post/{id:int}")]
        public ActionResult GetPost(int id)
        {
            var post = _service.GetPost(id);
            return new OkObjectResult(post);
        }

        [HttpPost("post")]
        public async Task<ActionResult> CreatePostAsync([FromBody] PostModel postModel)
        {
            var postId = await _service.CreatePostAsync(postModel);
            return CreatedAtAction(nameof(GetPost), new { id = postId }, postModel);
        }

        [HttpPut("post")]
        public async Task<ActionResult> UpdatePost([FromBody] PostUpdateModel postModel)
        {
            var postId = await _service.UpdatePost(postModel);
            return CreatedAtAction(nameof(GetPost), new { id = postId }, postModel);
        }

        [HttpDelete("post/{id:int}")]
        public async Task<ActionResult> DeletePostAsync(int id)
        {
            await _service.DeletePostAsync(id);

            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Post deletion was successful"
            });
        }

        [HttpPost("post/{id:int}/comment")]
        public async Task<ActionResult> CreatePostCommentAsync(int id, [FromBody] CommentCreateModel commentModel)
        {
            await _service.CreatePostCommentAsync(id, commentModel);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Comment created successfully"
            });
        }

        [HttpGet("post/{id:int}/comment")]
        public ActionResult GetAllCommentsByPost(int id)
        {
            var posts = _service.GetComments(id);
            return new OkObjectResult(posts);
        }

        [HttpDelete("post/{id:int}/comment/{commentId:int}")]
        public async Task<ActionResult> DeletePostCommentAsync(int id, int commentId)
        {
            await _service.DeletePostCommentAsync(id, commentId);
            return new OkObjectResult(new Response()
            {
                Status = StatusCodes.Status200OK,
                Message = "Comment deleted successfully"
            });
        }

        [HttpGet("post/{id:int}/comment/{commentId:int}")]
        public ActionResult GetComment(int id, int commentId)
        {
            var comment = _service.GetComment(commentId);
            return new OkObjectResult(comment);
        }
    }
}
