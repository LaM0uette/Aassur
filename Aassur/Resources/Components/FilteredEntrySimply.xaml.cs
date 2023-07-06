using Aassur.Core.Model;

namespace Aassur.Resources.Components;

public partial class FilteredEntrySimply 
{
    #region Statements
    
    public event EventHandler PickerIndexChanged;
    
    public Client Client { get; private set; }
    
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
    
    private void PickerSearch_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        Client = App.DbData.Clients.FirstOrDefault(c => c.FullName == PickerSearch.SelectedItem.ToString());
        
        PickerIndexChanged?.Invoke(this, e);
    }

    #endregion
    
    #region Functions

    private async void AddAllClientsInPicker()
    {
        while (!App.DbData.Clients.Any()){await Task.Delay(100); }
        
        PickerSearch.ItemsSource = App.DbData.Clients.Select(c => c.FullName).ToList();
    }
    
    public void SetPickerSearchSelection(string fullName)
    {
        PickerSearch.SelectedItem = fullName;
    }

    #endregion
}