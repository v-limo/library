namespace library.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByEmailAsync(string email);
    }
}
