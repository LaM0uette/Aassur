using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Resources.Components;

public partial class FilteredEntry
{
    #region Statements

    public FilteredEntry()
    {
        InitializeComponent();

        Task.Run(AddAllClientsInPicker);
    }

    #endregion
    
    #region Events

    private async void OnEntrySearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var clients = await GetAllClientsAsync();
        var filteredClients = App.Clients.Where(c => c.FullName.ToLower().Contains(EntrySearch.Text.ToLower())).ToList();
        PickerSearch.ItemsSource = filteredClients.Select(c => c.FullName).ToList();
    }

    #endregion
    
    #region Functions

    private async void AddAllClientsInPicker()
    {
        try
        {
            var clients = await GetAllClientsAsync();
            PickerSearch.Dispatcher.Dispatch(() =>
            {
                PickerSearch.ItemsSource = clients.Select(c => c.FullName).ToList();
            });
        }
        catch (Exception)
        {
            // ignored
        }
    }
    
    private static async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await SqliteService.Client.GetAllAsync();
    }

    #endregion
}