namespace library.Repositories.Implementations
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dBcontext;

        public AuthorRepository(ApplicationDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            List<Author> authors = await _dBcontext.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetById(int id)
        {
            Author author = await _dBcontext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }

        public async Task<Author> Create(Author entity)
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Author> author =
                await _dBcontext.Authors.AddAsync(entity);
            _ = await _dBcontext.SaveChangesAsync();
            return author.Entity;
        }

        public async Task<Author> Update(Author entity)
        {
            Author author = await _dBcontext.Authors.FirstOrDefaultAsync(a => a.Id == entity.Id);
            if (author == null)
            {
                return null;
            }

            author.Id = entity.Id;
            author.Name = entity.Name;
            author.Books = entity.Books;
            _ = await _dBcontext.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Delete(int id)
        {
            Author author = await _dBcontext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null)
            {
                return null;
            }
            _ = _dBcontext.Authors.Remove(author);
            return author;
        }
    }

}
