using Microsoft.AspNetCore.Mvc;
using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Services;

namespace ProgramowanieRozproszone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
    }
}
