using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Core.Data;

public class DbData
{
    #region Statements

    public IEnumerable<Client> Clients { get; private set; } = new List<Client>();
    public IEnumerable<ListCivility> ListCivility { get; private set; } = new List<ListCivility>();

    public DbData()
    {
        Task.Run(SetDbDatas);
    }

    #endregion
    
    private async void SetDbDatas()
    {
        Clients = await GetAllClientsAsync();
        ListCivility = await GetAllListCivilityAsync();
    }

    private static async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await SqliteService.Client.GetAllAsync();
    }
    
    private static async Task<IEnumerable<ListCivility>> GetAllListCivilityAsync()
    {
        return await SqliteService.ListCivility.GetAllAsync();
    }
}