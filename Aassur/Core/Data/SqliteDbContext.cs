using Aassur.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Aassur.Core.Data;

public class SqliteDbContext : DbContext
{
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var sqliteDbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Core", "DataBase", "Aassur.db");
        
        optionsBuilder.UseSqlite($"Data Source={sqliteDbPath}");
    }
}
