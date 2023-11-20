namespace Application.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService BookService)
    {
        _bookService = BookService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooksAsync()
    {
        var Books = await _bookService.GetAllBooksAsync();
        return Ok(Books);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BookDTO>> GetBookByIdAsync(int id)
    {
        var Book = await _bookService.GetBookByIdAsync(id);
        if (Book == null)
        {
            return NotFound($"Book with id {id} not found.");
        }
        return Ok(Book);
    }

    // [HttpGet("{email}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<ActionResult<BookDTO>> GetBookByEmailAsync(string email)
    // {
    //     var Book = await _bookService.GetBookByEmailAsync(email);
    //     if (Book == null)
    //     {
    //         return NotFound($"Book with email {email} not found.");
    //     }
    //     return Ok(Book);
    // }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookDTO>> CreateBookAsync([FromBody] Book Book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newBook = await _bookService.CreateBookAsync(Book);

        return CreatedAtAction(nameof(GetBookByIdAsync), new { id = newBook.Id }, newBook);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BookDTO>> UpdateBookAsync([FromBody] Book Book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _bookService.UpdateBookAsync(Book);
        // change service to return Book object
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteBookAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
