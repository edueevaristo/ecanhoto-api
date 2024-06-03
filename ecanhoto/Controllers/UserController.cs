using Microsoft.AspNetCore.Mvc;
using ecanhoto.Helpers;
using ecanhoto.Services;
using ecanhoto.Model;
using ecanhoto.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ecanhoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateOrUpdateUserRequest request)
        {
            var user = await _userService.Create(request);
            if (user == null)
                return BadRequest("Unable to create user");

            return Ok(user);
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] CreateOrUpdateUserRequest request)
        {
            var user = await _userService.Update(request);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        //[ApiController]  // Action method level
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] bool? isActive)
        {
            var users = await _userService.GetAll(isActive);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}