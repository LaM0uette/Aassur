using Aassur.Core.Model;

namespace Aassur.Core.Factory;

public class CoordFormFactory : FormFactory
{
    public override Grid CreateForm(Client client, List<string> titles)
    {
        var grid = CreateGrid(titles.Count);
        CreateTitleLabels(grid, titles);
        CreateLabels(grid, client);

        return grid;
    }
    
    protected override void CreateLabels(Layout grid, Client client)
    {
        var address = App.DbData.Address.FirstOrDefault(address => address.Id == client.AddressId)?.Name;
        var labelAddress = CreateLabel(address);
        AddElement(grid, labelAddress, 0, 1);
        
        var city = App.DbData.ListCity.FirstOrDefault(city => city.Id == client.CityId);
        var labelCodePostal = CreateLabel(city?.PostalCode);
        AddElement(grid, labelCodePostal, 1, 1);
        
        var labelCity = CreateLabel(city?.Name);
        AddElement(grid, labelCity, 2, 1);
        
        var labelMobile = CreateLabel(client.MobileNumber);
        AddElement(grid, labelMobile, 3, 1);
        
        var labelFixe = CreateLabel(client.FixeNumber);
        AddElement(grid, labelFixe, 4, 1);
        
        var labelMail = CreateLabel(client.Mail);
        AddElement(grid, labelMail, 5, 1);
    }
}