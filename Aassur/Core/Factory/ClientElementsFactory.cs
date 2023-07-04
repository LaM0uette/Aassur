using Aassur.Core.Model;
using Aassur.Pages;
using Aassur.Resources.Components;
using Microsoft.Maui.Controls.Shapes;

namespace Aassur.Core.Factory;

public static class ClientElementsFactory
{
    public static Grid CreateClientElements(Client client)
    {
        var grid = CreateGrid();
            
        var label = CreateLabel(client);
        AddElementToGrid(grid, label, row: 0, column: 0);
        
        var menuButton = CreateMenuFicheClientButton(client);
        AddElementToGrid(grid, menuButton, row: 0, column: 1);

        var line = CreateLine();
        AddElementToGrid(grid, line, row: 1, column: 0, columnSpan: 2);
            
        return grid;
    }

    private static Grid CreateGrid()
    {
        var grid = new Grid();
        
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2) });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5) });
        
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });

        return grid;
    }

    private static Label CreateLabel(Client client)
    {
        var civility = App.DbData.ListCivility.FirstOrDefault(civility => civility.Id == client.CivilityId)?.Name;
        var city = App.DbData.ListCity.FirstOrDefault(city => city.Id == client.CityId)?.Name;
        
        return new Label
        {
            Text = $"{civility} {client.FullName} - {client.Age}ans - {city}",
            TextColor = Color.FromRgb(227, 233, 234),
            VerticalTextAlignment = TextAlignment.End
        };
    }
    
    private static MenuFicheClientButton CreateMenuFicheClientButton(Client client)
    {
        var button = new MenuFicheClientButton
        {
            Text = "Fiche client",
            TextColor = Color.FromRgb(55, 190, 189),
            BorderColor = Colors.Transparent,
            BorderWidth = 0
        };
        
        button.Clicked += (_, _) => App.ChangeMainPage(new FicheClientPage(client));

        return button;
    }

    private static Line CreateLine()
    {
        return new Line
        {
            StrokeThickness = 2,
            BackgroundColor = Color.FromRgb(40, 47, 46)
        };
    }

    private static void AddElementToGrid(Layout grid, VisualElement element, int row, int column, int columnSpan = 1)
    {
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        Grid.SetColumnSpan(element, columnSpan);
        grid.Children.Add(element);
    }
}