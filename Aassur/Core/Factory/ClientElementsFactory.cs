using Aassur.Resources.Components;
using Microsoft.Maui.Controls.Shapes;

namespace Aassur.Core.Factory;

public class ClientElementsFactory
{
    public static Grid CreateClientElements(string clientInfo)
    {
        var grid = new Grid();

        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

        var label = new Label
        {
            Text = clientInfo,
            TextColor = Color.FromRgb(255, 0, 0),
            VerticalTextAlignment = TextAlignment.End
        };
        Grid.SetRow(label, 0);
        Grid.SetColumn(label, 0);

        grid.Children.Add(label);

        var menuButton = new MenuFicheClientButton();

        Grid.SetRow(menuButton, 0);
        Grid.SetColumn(menuButton, 1);

        grid.Children.Add(menuButton);

        var line = new Line
        {
            StrokeThickness = 2,
            BackgroundColor = Color.FromRgba(0, 255, 0, 0.1),
        };
        Grid.SetRow(line, 1);
        Grid.SetColumn(line, 0);
        Grid.SetColumnSpan(line, 2);

        grid.Children.Add(line);
        
        return grid;
    }
}