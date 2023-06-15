using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class News : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; }
}