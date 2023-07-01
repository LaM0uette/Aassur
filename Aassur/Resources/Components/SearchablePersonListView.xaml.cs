using Aassur.Core.Model;

namespace Aassur.Resources.Components;

public partial class SearchablePersonListView : ContentView
{
    public List<Person> _allPeople;
    
    public SearchablePersonListView()
    {
        InitializeComponent();
        _allPeople = GetPeople();
        PersonListView.ItemsSource = _allPeople;
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
            PersonListView.ItemsSource = _allPeople.Where(p => p.Name.ToLower().Contains(searchText.ToLower())).ToList();
            PersonListView.IsVisible = true;
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

public class Person
{
    public string Name { get; set; }
}