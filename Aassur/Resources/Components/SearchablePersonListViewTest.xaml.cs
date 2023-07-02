using Aassur.Core.Model;

namespace Aassur.Resources.Components;

public partial class SearchablePersonListViewTest : ContentView
{
    public List<Person> _allPeople;
    
    public SearchablePersonListViewTest()
    {
        InitializeComponent();
        _allPeople = GetPeople();
        PersonListView.ItemsSource = _allPeople;
        
        foreach(var person in _allPeople)
        {
            PersonPicker.Items.Add(person.Name);
        }
    }
    
    private void OnSearchEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = SearchEntry.Text;
        if (string.IsNullOrWhiteSpace(searchText))
        {
            PersonListView.IsVisible = false;
        }
        else
        {
            PersonListView.IsVisible = true;
            PersonListView.ItemsSource = _allPeople.Where(p => p.Name.ToLower().Contains(searchText.ToLower())).ToList();
        }
    }

    private void OnPersonListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Person selectedPerson = e.SelectedItem as Person;
        if (selectedPerson != null)
        {
            SearchEntry.Text = selectedPerson.Name;
            PersonListView.IsVisible = false;
        }
    }
    
    void OnPersonPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            string selectedPersonName = (string)picker.ItemsSource[selectedIndex];
            // You can do anything with selectedPersonName
        }
    }

    private List<Person> GetPeople()
    {
        // Remplacez cette méthode par la méthode qui charge votre liste de personnes
        return new List<Person>
        {
            new Person { Name = "Alice" },
            new Person { Name = "Bob" },
            new Person { Name = "Charlie" },
            // ...
        };
    }
}