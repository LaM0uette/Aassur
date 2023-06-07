using Aassur.Core.Data;

namespace Aassur.Core.Services.Repository;

public class RepositoryMySQL<T> : IRepository<T> where T : class
{
    private readonly MySqlDbContext _dbContext;
    
    public RepositoryMySQL(MySqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
