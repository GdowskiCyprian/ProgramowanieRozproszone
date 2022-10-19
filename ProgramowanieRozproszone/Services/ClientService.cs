using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Repositories;

namespace ProgramowanieRozproszone.Services
{
    public class ClientService
    {
        private ClientRepository _clientRepository;
        public ClientService()
        {
            _clientRepository = new ClientRepository();
        }
        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetClients().Concat(_clientRepository.GetClients2());
        }
    }
}
