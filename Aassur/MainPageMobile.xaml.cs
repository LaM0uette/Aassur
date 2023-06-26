using Aassur.Core.Model;
using Aassur.Core.Services;

namespace Aassur;

public partial class MainPageMobile
{
    private int count;

    public MainPageMobile()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        CounterBtn.Text = count.Equals(1) ? $"Clicked {count} time" : $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
        
        AddNewPerson(CounterBtn.Text);
    }

    private async void AddNewPerson(string name)
    {
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

        await SqliteService.Client.AddAsync(client);
    }
}