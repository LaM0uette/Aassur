using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class Meeting : IIdentifiable
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; }
}