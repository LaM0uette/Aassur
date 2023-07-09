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
}