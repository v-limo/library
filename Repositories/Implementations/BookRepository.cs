namespace library.Repositories.Implementations;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dBcontext;

    public BookRepository(ApplicationDbContext dBcontext)
    {
        _dBcontext = dBcontext;
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        var books = await _dBcontext.Books.ToListAsync();
        return books;
    }

    public async Task<Book> GetById(int id)
    {
        var book = await _dBcontext.Books.FirstOrDefaultAsync(b => b.Id == id);
        return book;
    }

    public async Task<Book> Create(Book entity)
    {
        var book = await _dBcontext.Books.AddAsync(entity);
        _ = await _dBcontext.SaveChangesAsync();
        return book.Entity;
    }

    public async Task<Book> Update(Book entity)
    {
        var book = await _dBcontext.Books.FirstOrDefaultAsync(b => b.Id == entity.Id);
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

    public async Task<Book> Delete(int id)
    {
        var book = await _dBcontext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
        {
            return null;
        }
        _ = _dBcontext.Books.Remove(book);
        _ = await _dBcontext.SaveChangesAsync();
        return book;
    }
}
