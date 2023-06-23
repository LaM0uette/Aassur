using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class ListCity : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    [MaxLength(5)] public string Insee { get; set; }
    [MaxLength(5)] public string PostalCode { get; set; }
    public string Name { get; set; }
    public double CoordX { get; set; }
    public double CoordY { get; set; }
}