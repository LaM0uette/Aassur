using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class LastContact : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    [Indexed] public int ClientId { get; set; }
    public DateTime Date { get; set; }
    public string Mode { get; set; }
    public string Note { get; set; }
}
