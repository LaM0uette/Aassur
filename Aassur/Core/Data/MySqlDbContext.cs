using Aassur.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Aassur.Core.Data;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=aassur;Uid=root;Pwd=2001;", 
            new MySqlServerVersion(new Version(8, 0, 33)));
    }
}
