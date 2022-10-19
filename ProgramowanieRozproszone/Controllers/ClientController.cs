using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Services;

namespace ProgramowanieRozproszone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _clientService.GetClients();
        }
    }
}
