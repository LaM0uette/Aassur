using Aassur.Pages;

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

    private void OnEntrySearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var filteredClients = App.DbData.Clients.Where(c => c.FullName.ToLower().Contains(EntrySearch.Text.ToLower())).ToList();
        PickerSearch.ItemsSource = filteredClients.Select(c => c.FullName).ToList();
    }
    
    private void SearchButton_OnClicked(object sender, EventArgs e)
    {
        if(PickerSearch?.SelectedItem is null) return;
        
        var client = App.DbData.Clients.FirstOrDefault(c => c.FullName == PickerSearch.SelectedItem.ToString());
        App.ChangeMainPage(new ClientPage(client));
    }

    #endregion
    
    #region Functions

    private async void AddAllClientsInPicker()
    {
        while (!App.DbData.Clients.Any()){await Task.Delay(100); }
        
        PickerSearch.ItemsSource = App.DbData.Clients.Select(c => c.FullName).ToList();
    }

    #endregion
}