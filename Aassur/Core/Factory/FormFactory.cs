using Aassur.Core.Data;
using Aassur.Core.Model;

namespace Aassur.Core.Factory;

public static class FormFactory
{
    private const int HEIGHT_ROW = 24;
    private const int WIDTH_COLUMNS = 100;

    public static Grid CreateForm(Client client, List<string> titles)
    {
        var grid = CreateGrid(titles.Count);
        grid.CreateTitleLabels(titles);

        return grid;
    }
    
    private static Grid CreateGrid(int nbRows)
    {
        var grid = new Grid();
        
        for (var i = 0; i < nbRows; i++)
            grid.RowDefinitions.Add(new RowDefinition { Height = HEIGHT_ROW });
        
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = WIDTH_COLUMNS });

        return grid;
    }
    
    private static void CreateTitleLabels(this Layout grid, IEnumerable<string> titles)
    {
        var i = 0;
        foreach (var label in titles.Select(CreateTitleLabel))
        {
            grid.AddElement(label, i, 0);
            i++;
        }
    }
    
    private static Label CreateTitleLabel(string text)
    {
        return new Label
        {
            Text = text,
            TextColor = StaticVar.WhiteColor,
            FontAttributes = FontAttributes.Bold
        };
    }
    
    private static Label CreateLabel(Client client)
    {
        var civility = App.DbData.ListCivility.FirstOrDefault(civility => civility.Id == client.CivilityId)?.Name;
        var city = App.DbData.ListCity.FirstOrDefault(city => city.Id == client.CityId)?.Name;
        
        return new Label
        {
            Text = $"{civility} {client.FullName} - {client.Age}ans - {city}",
            TextColor = StaticVar.WhiteColor,
            VerticalTextAlignment = TextAlignment.End
        };
    }
    
    private static void AddElement(this Layout grid, VisualElement element, int row, int column)
    {
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        grid.Children.Add(element);
    }
}