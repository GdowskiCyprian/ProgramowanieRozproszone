using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Repositories;

namespace ProgramowanieRozproszone.Services
{
    public class ProductService
    {
        private ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>() { new Product() { ProductId = 1, ProductName = "Product", ProductPrice = 12 } };
            //return _productRepository.GetProducts().Concat(_productRepository.GetProducts2());
        }
    }
}
