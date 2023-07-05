namespace Aassur.Resources.Components;

public partial class FilteredEntrySimply 
{
    #region Statements
    
    public FilteredEntrySimply()
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

    #endregion
    
    #region Functions

    private async void AddAllClientsInPicker()
    {
        while (!App.DbData.Clients.Any()){await Task.Delay(100); }
        
        PickerSearch.ItemsSource = App.DbData.Clients.Select(c => c.FullName).ToList();
    }

    #endregion
}