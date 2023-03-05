namespace library.Repositories.Interfaces;
public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
    Task<List<Book>> GetBooksByUserIdAsync(int userId);
    Task<Book> CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(Book book);
}
