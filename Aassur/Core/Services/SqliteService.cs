using Aassur.Core.Model;
using Aassur.Core.Services.Repository;
using Aassur.Core.Services.Repository.Sqlite;

namespace Aassur.Core.Services;

public static class SqliteService
{
    public static IRepository<Client> Client { get; private set; } = new ClientSqliteRepository();
}