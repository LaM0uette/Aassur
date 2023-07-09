using Aassur.Core.Data;
using Aassur.Core.Model;

namespace Aassur.Core.Factory;

public abstract class FormFactory
{
    #region Statements

    private const int HEIGHT_ROW = 24;
    private const int WIDTH_COLUMNS = 100;

    public abstract Grid CreateForm(Client client, List<string> titles);

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
    
    protected static void CreateLabels(Layout grid, Client client)
    {
        var address = App.DbData.Address.FirstOrDefault(address => address.Id == client.AddressId)?.Name;
        var labelAddress = CreateLabel(address);
        AddElement(grid, labelAddress, 0, 1);
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
    
    private static Label CreateLabel(string text)
    {
        return new Label
        {
            Text = text,
            WidthRequest = 200,
            TextColor = StaticVar.WhiteColor
        };
    }
    
    private static void AddElement(Layout grid, VisualElement element, int row, int column)
    {
        Grid.SetRow(element, row);
        Grid.SetColumn(element, column);
        grid.Children.Add(element);
    }

    #endregion
}