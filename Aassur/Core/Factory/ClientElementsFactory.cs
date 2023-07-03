using Aassur.Resources.Components;
using Microsoft.Maui.Controls.Shapes;

namespace Aassur.Core.Factory;

public static class ClientElementsFactory
{
    public static Grid CreateClientElements(string clientInfo)
    {
        var grid = CreateGrid(2);
            
        var label = CreateLabel(clientInfo);
        AddElementToGrid(grid, label, row: 0, column: 0);

        var menuButton = new MenuFicheClientButton();
        AddElementToGrid(grid, menuButton, row: 0, column: 1);

        var line = CreateLine();
        AddElementToGrid(grid, line, row: 1, column: 0, columnSpan: 2);
            
        return grid;
    }

    private static Grid CreateGrid(int size)
    {
        var grid = new Grid();
        for (int i = 0; i < size; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        return grid;
    }

    private static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            TextColor = Color.FromRgb(255, 0, 0),
            VerticalTextAlignment = TextAlignment.End
        };
    }

    private static Line CreateLine()
    {
        return new Line
        {
            StrokeThickness = 2,
            BackgroundColor = Color.FromRgba(0, 255, 0, 0.1)
        };
    }

    private static void AddElementToGrid(Grid grid, View element, int row, int column, int columnSpan = 1)
    {
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        Grid.SetColumnSpan(element, columnSpan);
        grid.Children.Add(element);
    }
}