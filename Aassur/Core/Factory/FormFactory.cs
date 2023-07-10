using Aassur.Core.Data;
using Aassur.Core.Model;

namespace Aassur.Core.Factory;

public abstract class FormFactory
{
    #region Statements

    protected struct ClientData
    {
        private string Address;
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

    #endregion
}