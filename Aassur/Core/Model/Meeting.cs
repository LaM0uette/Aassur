using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class Meeting : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    public string Date { get; set; }
    public string Note { get; set; }
}