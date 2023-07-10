using Aassur.Core.Services.Repository.Sqlite;

namespace Aassur.Core.Services;

public static class SqliteService
{
    public static ClientSqliteRepository Client { get; private set; } = new();
    public static AddressSqliteRepository Address { get; private set; } = new();
    public static ListCivilitySqliteRepository ListCivility { get; private set; } = new();
    public static ListCitySqliteRepository ListCity { get; private set; } = new();
    public static ListFamilyStatusSqliteRepository ListFamilyStatus { get; private set; } = new();
    public static ListNewsSqliteRepository ListNews { get; private set; } = new();
}