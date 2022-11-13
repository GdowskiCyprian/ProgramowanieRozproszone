using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Repositories;

namespace ProgramowanieRozproszone.Services
{
    public class ClientService
    {
        private ClientRepository _clientRepository;
        public ClientService()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            _clientRepository = new ClientRepository(configuration);
        }
        public IEnumerable<Client> GetClients()
        {
            //return new List<Client>() { 
            //    (new Client() { ClientAddress = "Address", ClientId = 1, ClientName = "Name" }) 
            //};
            return _clientRepository.GetClients().Concat(_clientRepository.GetClients2());
        }
    }
}
