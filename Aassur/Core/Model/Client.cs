using System.Globalization;
using Aassur.Core.Services.Repository;
using Aassur.Core.Utils;
using SQLite;

namespace Aassur.Core.Model;

public class Client : IIdentifiable
{
    [PrimaryKey, AutoIncrement, Indexed] public int Id { get; set; }
    [Indexed] public int CivilityId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Indexed] public int TypeClientId { get; set; }
    [Indexed] public int? AddressId { get; set; }
    [Indexed] public int? CityId { get; set; }
    public string MobileNumber { get; set; }
    public string FixeNumber { get; set; }
    public string Mail { get; set; }
    public string CountryOfResidence { get; set; }
    public string DateOfBirth { get; set; }
    [Indexed] public int FamilyStatusId { get; set; }
    public string Function { get; set; }
    public string Foyer { get; set; }
    public string Hobbies { get; set; }
    [Indexed] public int? RelatedCustomersClientId { get; set; }
    public string CreationDate { get; set; }
    public string LastModificationDate { get; set; }
    public string Origin { get; set; }
    public string Note { get; set; }
    
    [Ignore] public string FullName => $"{FirstName} {LastName}";
    [Ignore] public int Age => DateTime.Now.Year - DateOfBirth.ToDateTime().Year;

    public Client()
    {
        CivilityId = 1;
        TypeClientId = 1;
        FamilyStatusId = 1;
        CreationDate = DateTime.Now.ToDateString();
        LastModificationDate = DateTime.Now.ToDateString();
    }
}
