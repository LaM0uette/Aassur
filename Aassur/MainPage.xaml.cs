namespace Aassur;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Console.WriteLine(searchablePersonListView._allPeople.Count);
    }
}


