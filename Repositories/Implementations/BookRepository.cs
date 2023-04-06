namespace library.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dBcontext;

        public BookRepository(ApplicationDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            List<Book> books = await _dBcontext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            Book book = await _dBcontext.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Book> book = await _dBcontext.Books.AddAsync(entity);
            _ = await _dBcontext.SaveChangesAsync();
            return book.Entity;
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            Book book = await _dBcontext.Books.FirstOrDefaultAsync(b => b.Id == entity.Id);
            if (book == null)
            {
                return null;
            }

            book.Id = entity.Id;
            book.Title = entity.Title;
            book.Author = entity.Author;
            book.AuthorId = entity.AuthorId;
            _ = await _dBcontext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            Book book = await _dBcontext.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return null;
            }
            _ = _dBcontext.Books.Remove(book);
            _ = await _dBcontext.SaveChangesAsync();
            return book;
        }

        public Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            IQueryable<Book> books = _dBcontext.Books.Where(b => b.AuthorId == authorId);
            return books.ToListAsync();
        }

        public Task<List<Book>> GetBooksByUserIdAsync(int userId)
        {
            IQueryable<Book> books = _dBcontext.Books.Where(b => b.UserId == userId);
            return books.ToListAsync();
        }

        public Task<Book> GetAuthorByEmailAsync(string email)
        {
            Book book = _dBcontext.Books.FirstOrDefault(b => b.Author.Email == email);
            return Task.FromResult(book);
        }
    }
}
