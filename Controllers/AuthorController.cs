namespace library.Controllers;

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
        List<AuthorDTO> Authors = await _authorService.GetAllAuthorsAsync();
        return Ok(Authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthorByIdAsync(int id)
    {
        AuthorDTO Author = await _authorService.GetAuthorByIdAsync(id);
        return Author == null ? (ActionResult<AuthorDTO>)NotFound($"Author with id {id} not found.") : (ActionResult<AuthorDTO>)Ok(Author);
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<AuthorDTO>> GetAuthorByEmailAsync(string email)
    {
        AuthorDTO Author = await _authorService.GetAuthorByEmailAsync(email);
        return Author == null ? (ActionResult<AuthorDTO>)NotFound($"Author with email {email} not found.") : (ActionResult<AuthorDTO>)Ok(Author);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDTO>> CreateAuthorAsync([FromBody] Author Author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        AuthorDTO newAuthor = await _authorService.CreateAuthorAsync(Author);

        return CreatedAtAction(nameof(GetAuthorByIdAsync), new { id = newAuthor.Id }, newAuthor);
    }

    [HttpPut]
    public async Task<ActionResult<AuthorDTO>> UpdateAuthorAsync([FromBody] Author Author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _ = await _authorService.UpdateAuthorAsync(Author);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthorAsync(int id)
    {
        AuthorDTO Author = await _authorService.GetAuthorByIdAsync(id);
        if (Author == null)
        {
            return NotFound($"Author with id {id} not found.");
        }

        await _authorService.DeleteAuthorAsync(id);
        return NoContent();
    }
}
