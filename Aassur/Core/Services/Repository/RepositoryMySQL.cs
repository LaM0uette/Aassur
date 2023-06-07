using Aassur.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Aassur.Core.Services.Repository;

public class RepositoryMySQL<T> : IRepository<T> where T : class
{
    private readonly MySqlDbContext _dbContext;
    
    public RepositoryMySQL(MySqlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
