using Aassur.Core.Model;

namespace Aassur.Core.Factory;

public class ProfilFormFactory : FormFactory
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
        var clientData = GetClientData(client);
        
        var labelCountryOfResidence = CreateLabel(clientData.CountryOfResidence);
        AddElement(grid, labelCountryOfResidence, 0, 1);
        
        var labelDateOfBirth = CreateLabel(clientData.DateOfBirth);
        AddElement(grid, labelDateOfBirth, 1, 1);
        
        var labelFamilyStatus = CreateLabel(clientData.FamilyStatus);
        AddElement(grid, labelFamilyStatus, 2, 1);
        
        var labelFunction = CreateLabel(clientData.Function);
        AddElement(grid, labelFunction, 3, 1);
        
        var labelFoyer = CreateLabel(clientData.Foyer);
        AddElement(grid, labelFoyer, 4, 1);
        
        var labelHobbies = CreateLabel(clientData.Hobbies);
        AddElement(grid, labelHobbies, 5, 1);
        
        var labelRelatedCustomersClientId = CreateLabel(clientData.RelatedClientId);
        AddElement(grid, labelRelatedCustomersClientId, 6, 1);
        
        var labelCreationDate = CreateLabel(clientData.CreationDate);
        AddElement(grid, labelCreationDate, 7, 1);
        
        var labelOrigin = CreateLabel(clientData.Origin);
        AddElement(grid, labelOrigin, 8, 1);
    }
}