using library.Models;
using library.Repositories.Interfaces;

namespace library.Repositories.Implementations;


public class BookRepository : IBookRepository
{
    public Task<Book> CreateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<List<Book>> GetAllBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Book>> GetBooksByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
