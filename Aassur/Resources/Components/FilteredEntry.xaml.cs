using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur.Resources.Components;

public partial class FilteredEntry
{
    #region Statements
    
    private List<Client> Clients { get; set; }
    private List<Client> FilteredClients { get; set; }

    public FilteredEntry()
    {
        InitializeComponent();
        
        Clients = new List<Client>();
        FilteredClients = new List<Client>();
        
        PickerSearch.ItemsSource = FilteredClients.Select(c => c.FullName).ToList();
    }

    #endregion

    #region Functions

    private async void Test()
    {
        var clients = await GetClients();
        
        Clients = clients;
        FilteredClients = clients;
    }

    private async Task<List<Client>> GetClients()
    {
        var clients = await SqliteService.Client.GetByContainAsync(EntrySearch.Text.ToLower());
        return clients.ToList();
    }

    #endregion

    #region Events

    private void OnEntrySearchTextChanged(object sender, TextChangedEventArgs e)
    {
        Test();
        
        try
        {
            FilteredClients = Clients.Where(c => c.FullName.ToLower().Contains(EntrySearch.Text.ToLower())).ToList();
            PickerSearch.ItemsSource = FilteredClients.Select(c => c.FullName).ToList();
        }
        catch (Exception){ /* ignored */ }
    }
    
    void OnPickerSearchSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            string selectedPersonName = (string)picker.ItemsSource[selectedIndex];
            
            //EntrySearch.Text = selectedPersonName;
        }
    }

    #endregion
}