using FilmaiOutAPI.Models;
using FilmaiOutAPI.Models.Auth;
using FilmaiOutAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Controllers
{
    [ApiController]
    [Route("FilmaiOut/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserServices _userServices;

        public AuthController(UserServices authServices)
        {
            _userServices = authServices;
        }

        [HttpPost("login")]
        public ActionResult Login([FromQuery] LoginModel userLogin)
        {
            return _userServices.LogUserIn(userLogin)
                ? new OkObjectResult(new Response()
                {
                    Status = StatusCodes.Status200OK,
                    Message = "User login successful"
                })
                : new NotFoundObjectResult(new Response()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Check username or password"
                });
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromQuery] RegisterModel registerModel)
        {
            return await _userServices.RegisterAsync(registerModel)
                ? new OkObjectResult(new Response()
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Registration successful"
                })
                : new BadRequestObjectResult(new Response()
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Registration failed"
                });
        }

        [HttpDelete]
        public ActionResult DeleteUserAsync(string name)
        {
            return _userServices.DeleteUserAsync(name)
                ? new OkObjectResult(new Response()
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Success"
                })
                : new BadRequestObjectResult(new Response()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Failed"
                });
        }
    }
}
