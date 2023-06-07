using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aassur.Core.Model;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int? CivilityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}