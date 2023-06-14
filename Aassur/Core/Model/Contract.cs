using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class Contract : IIdentifiable
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public int ClientId { get; set; }
    public int TypeContractId { get; set; }
    public int CompanyId { get; set; }
    public string ContractName { get; set; }
    public int? Encours { get; set; }
    public DateTime OpeningDate { get; set; }
}
