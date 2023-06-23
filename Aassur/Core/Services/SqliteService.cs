using Aassur.Core.Model;
using Aassur.Core.Services.Repository;

namespace Aassur.Core.Services;

public static class SqliteService
{
    public static IRepository<Client> Client { get; private set; } = new ClientSqliteRepository();
}