using library.DTOs;
using library.Models;
using library.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersAsync()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound($"User with id {id} not found.");
        }
        return Ok(user);
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<UserDTO>> GetUserByEmailAsync(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            return NotFound($"User with email {email} not found.");
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUserAsync([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newUser = await _userService.CreateUserAsync(user);

        return CreatedAtAction(nameof(GetUserByIdAsync), new { id = newUser.Id }, newUser);
    }

    [HttpPut]
    public async Task<ActionResult<UserDTO>> UpdateUserAsync([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _userService.UpdateUserAsync(user);
        // change service to return user object
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserAsync(int id)
    {
        await _userService.DeleteUserAsync(id);
        return NoContent();
    }
}
