using Aassur.Core.Model;

namespace Aassur.Core.Services;

public class ClientSqliteRepository : SqliteRepository<Client>
{
    public ClientSqliteRepository() : base()
    {
    }
}