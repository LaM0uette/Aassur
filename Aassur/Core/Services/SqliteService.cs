using Aassur.Core.Services.Repository.Sqlite;

namespace Aassur.Core.Services;

public static class SqliteService
{
    public static ClientSqliteRepository Client { get; private set; } = new();
    public static ListCivilitySqliteRepository ListCivility { get; private set; } = new();
}