using ProgramowanieRozproszone.Helpers;
using ProgramowanieRozproszone.Models;
using System.Data;

namespace ProgramowanieRozproszone.Repositories
{
    public class ProductRepository
    {
        private readonly MsSqlProvider _msSqlProvider;
        private readonly MsSqlProvider _msSqlProvider2;
        private string _connectionString;
        private string _connectionString2;
        public ProductRepository()
        {
            _connectionString = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone1;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _connectionString2 = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone2;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _msSqlProvider = new MsSqlProvider(_connectionString);
            _msSqlProvider2 = new MsSqlProvider(_connectionString2);
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
