using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class ListCivility : IIdentifiable
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    [MaxLength(4)] public string Name { get; set; }
}