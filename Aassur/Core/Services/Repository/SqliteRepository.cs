using SQLite;

namespace Aassur.Core.Services.Repository;

public class SqliteRepository<T> : IRepository<T> where T : class, new()
{
    protected readonly SQLiteAsyncConnection Database;

    protected SqliteRepository()
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Aassur", "Aassur.db");
        Database = new SQLiteAsyncConnection(dbPath);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Database.Table<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await Database.Table<T>()
            .FirstOrDefaultAsync(c => ((IIdentifiable)c).Id == id);
    }

    public async Task<bool> AddAsync(T entity)
    {
        return await Database.InsertAsync(entity) > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        return await Database.UpdateAsync(entity) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await Database.DeleteAsync<T>(id) > 0;
    }
}