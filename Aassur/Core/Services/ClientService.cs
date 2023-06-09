using Aassur.Core.Model;

namespace Aassur.Core.Services;

public class ClientService
{
    private readonly IRepository<Client> _clientRepository;

    public ClientService(IRepository<Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IEnumerable<Client>> GetClients()
    {
        return await _clientRepository.GetAllAsync();
    }
}