using Aassur.Core.Data;
using Aassur.Core.Factory;
using Aassur.Core.Model;

namespace Aassur;

public partial class MainPage
{
    #region Statements

    public MainPage()
    {
        InitializeComponent();
        
        Task.Run(AddRecentClients);
    }

    #endregion
    
    #region Functions

    private async void AddRecentClients()
    {
        while (DbData.ShouldDelay()){ await Task.Delay(100); }
        
        var clientsList = GetLatestRecentClients();
        AddRecentClientsToLayout(clientsList);
    }

    private static List<Client> GetLatestRecentClients()
    {
        return App.DbData.Clients
            .OrderByDescending(client => client.LastModificationDate)
            .Take(3)
            .ToList();
    }
    
    private void AddRecentClientsToLayout(List<Client> clientsList)
    {
        foreach (var client in clientsList)
        {
            StackLayoutRecentClients.Children.Add(ClientElementsFactory.CreateClientElements(client));
        }
    }

    #endregion
}