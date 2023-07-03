using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Core.Data;

public class DbData
{
    #region Statements

    public IEnumerable<Client> Clients { get; set; } = new List<Client>();

    public DbData()
    {
        Task.Run(SetClients);
    }

    #endregion

    #region Functions

    private async void SetClients()
    {
        var clients = await GetAllClientsAsync();
        Clients = clients;
    }
    
    public static async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await SqliteService.Client.GetAllAsync();
    }

    #endregion
}