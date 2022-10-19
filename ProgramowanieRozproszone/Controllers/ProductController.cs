using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;

namespace ProgramowanieRozproszone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            //get all 
            throw new NotImplementedException();
        }
    }
}
