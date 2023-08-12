namespace library.Repositories.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
        Task<List<Book>> GetBooksByUserIdAsync(int userId);
        Task<Book> GetAuthorByEmailAsync(string email);
    }
}
