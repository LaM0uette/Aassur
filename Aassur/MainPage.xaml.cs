using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur;

public partial class MainPage : ContentPage
{
    int count;
    private IRepository<Client> _clientRepository;

    public MainPage()
    {
        InitializeComponent();
    }
    
    private void Init()
    {
        if (_clientRepository is not null)
            return;

        _clientRepository = new SqliteRepository<Client>("D:\\Projets\\App\\Aassur\\Aassur\\Core\\DataBase\\Aassur.db");
    }

    public async void AddNewPerson(string name)
    {
        Init();

        // Create a new client
        var client = new Client
        {
            Id = count,
            CivilityId = 1,
            TypeClientId = 1,
            FamilyStatusId = 1,
            FirstName = name,
            LastName = "CaVa",
            DateOfBirth = DateTime.Now
        };

        await _clientRepository.AddAsync(client);
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        
        AddNewPerson("Johnny");
    }
}