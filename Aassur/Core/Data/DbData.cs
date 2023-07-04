using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Core.Data;

public class DbData
{
    #region Statements

    public IEnumerable<Client> Clients { get; private set; } = new List<Client>();
    public IEnumerable<ListCivility> ListCivility { get; private set; } = new List<ListCivility>();
    public IEnumerable<ListCity> ListCity { get; private set; } = new List<ListCity>();
    public IEnumerable<ListNews> ListNews { get; private set; } = new List<ListNews>();

    public DbData()
    {
        Task.Run(SetDbDatas);
    }

    #endregion
    
    private async void SetDbDatas()
    {
        Clients = await SqliteService.Client.GetAllAsync();
        ListCivility = await SqliteService.ListCivility.GetAllAsync();
        ListCity = await SqliteService.ListCity.GetAllAsync();
        ListNews = await SqliteService.ListNews.GetAllAsync();
    }
    
    public static bool ShouldDelay()
    {
        return !App.DbData.Clients.Any() 
               && !App.DbData.ListCivility.Any() 
               && !App.DbData.ListCity.Any()
               && !App.DbData.ListNews.Any();
    }
}