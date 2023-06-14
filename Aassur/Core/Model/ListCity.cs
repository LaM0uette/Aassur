using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class ListCity : IIdentifiable
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    [MaxLength(5)] public string Insee { get; set; }
    [MaxLength(5)] public string PostalCode { get; set; }
    public string Name { get; set; }
    public double CoordX { get; set; }
    public double CoordY { get; set; }
}