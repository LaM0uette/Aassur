using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class ListFamilyStatus : IIdentifiable
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public string Name { get; set; }
}