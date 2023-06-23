using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class Address : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    public string Name { get; set; }
    public double CoordX { get; set; }
    public double CoordY { get; set; }
}