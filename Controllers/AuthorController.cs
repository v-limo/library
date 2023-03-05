using library.DTOs;
using library.Models;
using library.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAllAuthorsAsync()
    {
        var Authors = await _authorService.GetAllAuthorsAsync();
        return Ok(Authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthorByIdAsync(int id)
    {
        var Author = await _authorService.GetAuthorByIdAsync(id);
        if (Author == null)
        {
            return NotFound($"Author with id {id} not found.");
        }
        return Ok(Author);
    }

    // [HttpGet("{email}")]
    // public async Task<ActionResult<AuthorDTO>> GetAuthorByEmailAsync(string email)
    // {
    //     var Author = await _authorService.GetAuthorByEmailAsync(email);
    //     if (Author == null)
    //     {
    //         return NotFound($"Author with email {email} not found.");
    //     }
    //     return Ok(Author);
    // }

    [HttpPost]
    public async Task<ActionResult<AuthorDTO>> CreateAuthorAsync([FromBody] Author Author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newAuthor = await _authorService.CreateAuthorAsync(Author);

        return CreatedAtAction(nameof(GetAuthorByIdAsync), new { id = newAuthor.Id }, newAuthor);
    }

    [HttpPut]
    public async Task<ActionResult<AuthorDTO>> UpdateAuthorAsync([FromBody] Author Author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _authorService.UpdateAuthorAsync(Author);
        // change service to return Author object
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorAsync(int id)
    {
        // await _AuthorService.DeleteAuthorAsync(id);
        return NoContent();
    }
}
