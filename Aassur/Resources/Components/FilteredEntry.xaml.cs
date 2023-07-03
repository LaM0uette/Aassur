using Aassur.Core.Data;

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

    #endregion
    
    #region Functions

    private async void AddAllClientsInPicker()
    {
        PickerSearch.ItemsSource = (await DbData.GetAllClientsAsync()).Select(c => c.FullName).ToList();
    }

    #endregion
}