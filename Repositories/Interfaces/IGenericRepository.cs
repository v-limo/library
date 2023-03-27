namespace library.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}

