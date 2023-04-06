using library.DTOs;
using library.Models;
using library.Service.Interfaces;

using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooksAsync()
    {
        var Books = await _bookService.GetAllBooksAsync();
        return Ok(Books);
    }

    [HttpGet("{id}")]
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
    public async Task<ActionResult> DeleteBookAsync(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
