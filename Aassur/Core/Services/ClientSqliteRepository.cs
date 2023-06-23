using Aassur.Core.Model;

namespace Aassur.Core.Services;

public class ClientSqliteRepository : SqliteRepository<Client>, IRepository<Client>
{
    public ClientSqliteRepository(string dbPath) : base(dbPath)
    {
    }
}