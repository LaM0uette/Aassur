using System.ComponentModel.DataAnnotations.Schema;
using Aassur.Core.Services;

namespace Aassur.Core.Model;

[Table("clients")]
public class Client : IIdentifiable
{
    [Column("id")]
    public int Id { get; set; }

    [Column("civility_id")]
    public int? CivilityId { get; set; }
    
    [Column("first_name")]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    public string LastName { get; set; }
}
