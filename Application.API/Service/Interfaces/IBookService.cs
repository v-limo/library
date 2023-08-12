namespace library.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<List<BookDTO>> GetBooksByAuthorIdAsync(int authorId);
        Task<List<BookDTO>> GetBooksByUserIdAsync(int userId);
        Task<BookDTO> CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<BookDTO> GetAuthorByEmailAsync(string email);
    }
}
