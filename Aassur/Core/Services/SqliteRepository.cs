using SQLite;

namespace Aassur.Core.Services;

public class SqliteRepository<T> : IRepository<T> where T : class, new()
{
    private readonly SQLiteAsyncConnection _database;

    public SqliteRepository(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _database.Table<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _database.Table<T>()
            .FirstOrDefaultAsync(c => ((IIdentifiable)c).Id == id);
    }

    public async Task<bool> AddAsync(T entity)
    {
        return await _database.InsertAsync(entity) > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        return await _database.UpdateAsync(entity) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _database.DeleteAsync<T>(id) > 0;
    }
}