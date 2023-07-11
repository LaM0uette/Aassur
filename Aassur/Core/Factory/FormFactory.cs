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
        public string Mail;
        public string CountryOfResidence;
        public string DateOfBirth;
        public string FamilyStatus;
        public string Function;
        public string Foyer;
        public string Hobbies;
        public string RelatedClientId;
        public string CreationDate;
        public string Origin;
    }

    public abstract Grid CreateForm(Client client, List<string> titles);

    protected abstract void CreateLabels(Layout grid, Client client);

    #endregion

    #region Functions

    protected static Grid CreateGrid(int nbRows)
    {
        var grid = new Grid
        {
            ColumnSpacing = 10,
            RowSpacing = 12,
            Margin = new Thickness(0, 20, 0, 0)
        };

        for (var i = 0; i < nbRows; i++)
            grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(1, GridUnitType.Auto)});

        grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Auto)});
        grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Auto)});

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
            FontSize = 16,
            HorizontalTextAlignment = TextAlignment.End,
            TextColor = StaticVar.WhiteColor,
            FontAttributes = FontAttributes.Bold
        };
    }

    protected static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            FontSize = 16,
            WidthRequest = 300,
            LineBreakMode = LineBreakMode.WordWrap,
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

        var relatedClients = new List<string>();
        if (client.RelatedClientId.Contains(':'))
        {
            relatedClients.AddRange(client.RelatedClientId
                .Split(':')
                .Select(relatedClient =>
                    App.DbData.Clients.FirstOrDefault(c => c.Id == int.Parse(relatedClient))).Select(c => c?.FullName));
        }
        else
        {
            relatedClients.Add(App.DbData.Clients.FirstOrDefault(c => c.Id == int.Parse(client.RelatedClientId))?.FullName);
        }

        return new ClientData
        {
            Address = address?.Name,
            PostalCode = city?.PostalCode,
            City = city?.Name,
            MobileNumber = client.MobileNumber,
            FixeNumber = client.FixeNumber,
            Mail = client.Mail,
            CountryOfResidence = client.CountryOfResidence,
            DateOfBirth = client.DateOfBirth,
            FamilyStatus = family?.Name,
            Function = client.Function,
            Foyer = client.Foyer,
            Hobbies = client.Hobbies,
            RelatedClientId = string.Join(", ", relatedClients),
            CreationDate = client.CreationDate,
            Origin = client.Origin
        };
    }

    #endregion
}