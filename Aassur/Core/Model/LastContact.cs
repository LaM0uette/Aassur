using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class LastContact : IIdentifiable
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public string Mode { get; set; }
    public string Note { get; set; }
}
