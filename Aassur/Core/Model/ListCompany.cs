using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class ListCompany : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    public string Name { get; set; }
    public bool Partner { get; set; }
}