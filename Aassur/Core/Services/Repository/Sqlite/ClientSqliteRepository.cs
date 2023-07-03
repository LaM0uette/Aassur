using Aassur.Core.Model;

namespace Aassur.Core.Services.Repository.Sqlite;

public class ClientSqliteRepository : SqliteRepository<Client>
{
    public async Task<IEnumerable<Client>> GetByContainAsync(string text)
    {
        return await Database.Table<Client>()
            .Where(c => c.FirstName.ToLower().Contains(text.ToLower()) || c.LastName.ToLower().Contains(text.ToLower()))
            .ToListAsync();
    }
}