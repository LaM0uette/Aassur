using Aassur.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Aassur.Core.Data;

public class SqlServerDbContext : DbContext
{
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
}
