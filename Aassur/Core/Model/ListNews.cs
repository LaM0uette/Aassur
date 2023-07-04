using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class ListNews : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    public string Name { get; set; }
    [MaxLength(7)] public string Color { get; set; }
}