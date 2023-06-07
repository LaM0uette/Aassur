using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Aassur.Core.Model;
using Aassur.Core.Services.Repository;

namespace Aassur.ViewModel;

public sealed class MainPageViewModel : INotifyPropertyChanged
{
    private readonly IRepository<Client> _clientRepository;
    private int _count;
    private ObservableCollection<Client> _clients;

    public MainPageViewModel(IRepository<Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public MainPageViewModel()
    {
    }

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            OnPropertyChanged(nameof(Count));
        }
    }

    public ObservableCollection<Client> Clients
    {
        get => _clients;
        set
        {
            _clients = value;
            OnPropertyChanged(nameof(Clients));
        }
    }

    public ICommand CounterClickedCommand => new Command(async () => await OnCounterClicked());

    private async Task OnCounterClicked()
    {
        Count++;

        if (Count >= 5)
        {
            var clients = await _clientRepository.GetAllAsync();
            Clients = new ObservableCollection<Client>(clients);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}