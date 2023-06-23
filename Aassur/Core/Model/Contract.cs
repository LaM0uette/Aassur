using Aassur.Core.Services.Repository;
using SQLite;

namespace Aassur.Core.Model;

public class Contract : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    [Indexed] public int ClientId { get; set; }
    [Indexed] public int TypeContractId { get; set; }
    [Indexed] public int CompanyId { get; set; }
    public string ContractName { get; set; }
    public int? Encours { get; set; }
    public DateTime OpeningDate { get; set; }
}
