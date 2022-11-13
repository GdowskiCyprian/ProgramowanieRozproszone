using Microsoft.Extensions.Configuration;
using ProgramowanieRozproszone.Helpers;
using ProgramowanieRozproszone.Models;
using System.Data;

namespace ProgramowanieRozproszone.Repositories
{
    public class ProductRepository
    {
        private readonly MsSqlProvider _msSqlProvider;
        private readonly MsSqlProvider _msSqlProvider2;
        private IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _msSqlProvider = new MsSqlProvider(_configuration.GetValue<string>("ConnectionStrings:connectionString1"));
            _msSqlProvider2 = new MsSqlProvider(_configuration.GetValue<string>("ConnectionStrings:connectionString2"));
        }
        public IEnumerable<Product> GetProducts()
        {
            _msSqlProvider.ExecuteQuery(out DataTable table, "Select * from Products");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        public IEnumerable<Product> GetProducts2()
        {
            _msSqlProvider2.ExecuteQuery(out DataTable table, "Select * from Products");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        private Product RowToModel(DataRow row) =>
            new Product
            {
                ProductId = row.GetValueAsInt("ProductId"),
                ProductName = row.GetValueAsString("ProductName"),
                ProductPrice = row.GetValueAsDouble("ProductPrice")
            };

    }
}
