using Aassur.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Aassur.Core.Data;

public class SqliteDbContext : DbContext
{
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
}
