using Aassur.Core.Data;
using Aassur.Core.Model;

namespace Aassur.Core.Factory;

public abstract class FormFactory
{
    #region Statements

    protected struct ClientData
    {
        public string Address;
        public string PostalCode;
        public string City;
        public string MobileNumber;
        public string FixeNumber;
        public string CountryOfResidence;
        public string DateOfBirth;
        public string FamilyStatus;
        public string Function;
        public string Foyer;
        public string Hobbies;
        public int? RelatedCustomersClientId;
        public string CreationDate;
        public string Origin;
    }
    
    private const int HEIGHT_ROW = 24;
    private const int WIDTH_COLUMNS = 100;

    public abstract Grid CreateForm(Client client, List<string> titles);

    protected abstract void CreateLabels(Layout grid, Client client);

    #endregion

    #region Functions

    protected static Grid CreateGrid(int nbRows)
    {
        var grid = new Grid();
        
        for (var i = 0; i < nbRows; i++)
            grid.RowDefinitions.Add(new RowDefinition { Height = HEIGHT_ROW });
        
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = WIDTH_COLUMNS });

        return grid;
    }
    
    protected static void CreateTitleLabels(Layout grid, IEnumerable<string> titles)
    {
        var i = 0;
        foreach (var label in titles.Select(CreateTitleLabel))
        {
            AddElement(grid, label, i, 0);
            i++;
        }
    }
    
    private static Label CreateTitleLabel(string text)
    {
        return new Label
        {
            Text = $"{text} : ",
            TextColor = StaticVar.WhiteColor,
            FontAttributes = FontAttributes.Bold
        };
    }
    
    protected static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            WidthRequest = 200,
            TextColor = StaticVar.WhiteColor
        };
    }
    
    protected static void AddElement(Layout grid, VisualElement element, int row, int column)
    {
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        grid.Children.Add(element);
    }
    
    protected static ClientData GetClientData(Client client)
    {
        var address = App.DbData.Address.FirstOrDefault(address => address.Id == client.AddressId);
        var city = App.DbData.ListCity.FirstOrDefault(city => city.Id == client.CityId);
        var family = App.DbData.ListFamilyStatus.FirstOrDefault(family => family.Id == client.FamilyStatusId);
        
        return new ClientData
        {
            Address = address?.Name,
            PostalCode = city?.PostalCode,
            City = city?.Name,
            MobileNumber = client.MobileNumber,
            FixeNumber = client.FixeNumber,
            CountryOfResidence = client.CountryOfResidence,
            DateOfBirth = client.DateOfBirth,
            FamilyStatus = family?.Name,
            Function = client.Function,
            Foyer = client.Foyer,
            Hobbies = client.Hobbies,
            RelatedCustomersClientId = client.RelatedCustomersClientId,
            CreationDate = client.CreationDate,
            Origin = client.Origin
        };
    }

    #endregion
}