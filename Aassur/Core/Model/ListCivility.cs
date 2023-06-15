using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class ListCivility : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    [MaxLength(3)] public string Name { get; set; }
}