using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;

namespace ProgramowanieRozproszone.Controllers
{
    [ApiController]
    public class ClientController : Controller
    {
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            //get all 
            throw new NotImplementedException();
        }
    }
}
