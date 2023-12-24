using LibraryApp.Domain.Entities;
namespace LibraryApp.Domain.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
    Task<List<Book>> GetBooksByUserIdAsync(int userId);
    Task<Book> GetAuthorByEmailAsync(string email);
}
