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
            return new List<Client>() { 
                (new Client() { ClientAddress = "Address", ClientId = 1, ClientName = "Name" }) 
            };
            //return _clientRepository.GetClients().Concat(_clientRepository.GetClients2());
        }
    }
}
