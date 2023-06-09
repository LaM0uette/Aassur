using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur;

public partial class MainPage : ContentPage
{
    private int count;
    private readonly IRepository<Client> _clientRepository;

    public MainPage()
    {
        InitializeComponent();

        var dbPath = "D:\\Projets\\App\\Aassur\\Aassur\\Core\\DataBase\\Aassur.db";
        _clientRepository = new SqliteRepository<Client>(dbPath);
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        
        // Create a new client
        var client = new Client 
        { 
            FirstName = "John", 
            LastName = "Doe" 
        };
        await _clientRepository.AddAsync(client);
    }
}