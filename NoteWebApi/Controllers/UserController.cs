using Microsoft.AspNetCore.Mvc;
using NoteWebApi.Dtos;
using NoteWebApi.Services.Repositories;

namespace NoteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);

            if (result == null)
            {
                return BadRequest(result.Errors);
            }

            return CreatedAtAction(nameof(GetUser), new { id = result.Data.Id }, result.Data);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetByIdUserAsync(id);
            if (result == null)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUserAsync();
            return Ok(result.Data);

        }
    }
}
