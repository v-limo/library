using library.DTOs;
using library.Models;
using library.Service.Interfaces;

namespace library.Service.Implementations;


public class BookService : IBookService
{
    public Task<BookDTO> CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookDTO>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BookDTO> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookDTO>> GetBooksByAuthorIdAsync(int authorId)
    {
        throw new NotImplementedException();
    }

    public Task<List<BookDTO>> GetBooksByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
