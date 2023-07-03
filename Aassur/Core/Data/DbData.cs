using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Core.Data;

public class DbData
{
    public IEnumerable<Client> Clients { get; set; } = new List<Client>();

    public DbData()
    {
        Task.Run(AddAllClients);
    }
    
    private async void AddAllClients()
    {
        var clients = await GetAllClientsAsync();
        Clients = clients;
    }
    
    private static async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await SqliteService.Client.GetAllAsync();
    }
}