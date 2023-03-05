using library.DTOs;
using library.Models;
using library.Repositories.Interfaces;
using library.Service.Interfaces;

namespace library.Service.Implementations;

public class BookService : IBookService
{
    // Will implement unit of work pattern and auto mapper in the future
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookDTO> CreateBookAsync(Book book)
    {
        var createdBook = await _bookRepository.CreateBookAsync(book);

        var bookDTO = new BookDTO
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            AuthorId = createdBook.AuthorId,
            UserId = createdBook.UserId,
        };

        return bookDTO;
    }

    public async Task DeleteBookAsync(Book book)
    {
        await _bookRepository.DeleteBookAsync(book);
    }

    public async Task<List<BookDTO>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();

        var bookDTOs = new List<BookDTO>();

        foreach (var book in books)
        {
            var bookDTO = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                UserId = book.UserId,
            };

            bookDTOs.Add(bookDTO);
        }
        return bookDTOs;
    }

    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);

        var bookDTO = new BookDTO
        {
            Id = book.Id,
            Title = book.Title,
            AuthorId = book.AuthorId,
            UserId = book.UserId,
        };

        return bookDTO;
    }

    public async Task<List<BookDTO>> GetBooksByAuthorIdAsync(int authorId)
    {
        var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);

        var bookDTOs = new List<BookDTO>();

        foreach (var book in books)
        {
            var bookDTO = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                UserId = book.UserId,
            };

            bookDTOs.Add(bookDTO);
        }
        return bookDTOs;
    }

    public async Task<List<BookDTO>> GetBooksByUserIdAsync(int userId)
    {
        var books = await _bookRepository.GetBooksByUserIdAsync(userId);

        var bookDTOs = new List<BookDTO>();

        foreach (var book in books)
        {
            var bookDTO = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                UserId = book.UserId,
            };

            bookDTOs.Add(bookDTO);
        }
        return bookDTOs;
    }

    public async Task UpdateBookAsync(Book book)
    {
        await _bookRepository.UpdateBookAsync(book);
    }
}
