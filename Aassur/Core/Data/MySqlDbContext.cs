using Aassur.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Aassur.Core.Data;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
}
