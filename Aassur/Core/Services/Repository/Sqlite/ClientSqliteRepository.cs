using Aassur.Core.Model;

namespace Aassur.Core.Services.Repository.Sqlite;

public class ClientSqliteRepository : SqliteRepository<Client>
{
    public async Task<IEnumerable<Client>> GetByContainAsync(string text)
    {
        var allClients = await Database.Table<Client>().ToListAsync();
        return allClients.Where(c => (c.FirstName + " " + c.LastName).ToLower().Contains(text.ToLower()));
    }
}