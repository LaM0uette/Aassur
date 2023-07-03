using Aassur.Core.Model;

namespace Aassur.Resources.Components;

public partial class FilteredEntry
{
    #region Statements
    
    private readonly List<Client> Clients = new()
    {
        new Client{ Id = 1, FirstName = "FirstName 1", LastName = "LastName 1" },
        new Client{ Id = 2, FirstName = "FirstName 2", LastName = "LastName 2" },
        new Client{ Id = 3, FirstName = "FirstName 3", LastName = "LastName 3" },
        new Client{ Id = 4, FirstName = "FirstName 4", LastName = "LastName 4" },
        new Client{ Id = 5, FirstName = "FirstName 5", LastName = "LastName 5" },
        new Client{ Id = 6, FirstName = "Paul", LastName = "zae" },
        new Client{ Id = 7, FirstName = "Pascal", LastName = "dfsdf" },
        new Client{ Id = 8, FirstName = "Greorge", LastName = "fhfgh" },
    };

    private List<Client> FilteredClients { get; set; }

    public FilteredEntry()
    {
        InitializeComponent();

        FilteredClients = Clients;
        PickerSearch.ItemsSource = FilteredClients.Select(c => c.FullName).ToList();
    }

    #endregion

    #region Events

    private void OnEntrySearchTextChanged(object sender, TextChangedEventArgs e)
    {
        if (Clients.Any(c => c.FullName.ToLower().Equals(EntrySearch.Text.ToLower())))
        {
            return;
            PickerSearch.ItemsSource = FilteredClients.Select(c => c.FullName).ToList();
        }
        else
        {
            try
            {
                FilteredClients = Clients.Where(c => c.FullName.ToLower().Contains(EntrySearch.Text.ToLower())).ToList();
                PickerSearch.ItemsSource = FilteredClients.Select(c => c.FullName).ToList();
            }
            catch (Exception){ /* ignored */ }
        }
    }
    
    void OnPickerSearchSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            string selectedPersonName = (string)picker.ItemsSource[selectedIndex];
            
            EntrySearch.Text = selectedPersonName;
        }
    }

    #endregion
}