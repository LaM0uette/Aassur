using Aassur.Core.Services;
using SQLite;

namespace Aassur.Core.Model;

public class Client : IIdentifiable
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public int CivilityId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public int TypeClientId { get; set; }
    
    public int AdressId { get; set; }
    
    public int CityId { get; set; }
    
    public string MobileNumber { get; set; }
    
    public string FixeNumber { get; set; }
    
    public string Mail { get; set; }
    
    public string CountryOfResidence { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public int FamilyStatusId { get; set; }
    
    public string Function { get; set; }
    
    public string Foyer { get; set; }
    
    public string Hobbies { get; set; }
    
    public int RelatedCustomersClientId { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public string Origin { get; set; }
    
    public string Note { get; set; }
}
