using ProgramowanieRozproszone.Helpers;
using ProgramowanieRozproszone.Models;
using System.Data;

namespace ProgramowanieRozproszone.Repositories
{
    public class OrderRepository
    {
        private readonly MsSqlProvider _msSqlProvider;
        private readonly MsSqlProvider _msSqlProvider2;
        private string _connectionString;
        private string _connectionString2;
        private string query;
        public OrderRepository()
        {
            _connectionString = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone1;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _connectionString2 = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone2;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _msSqlProvider = new MsSqlProvider(_connectionString);
            _msSqlProvider2 = new MsSqlProvider(_connectionString2);
            query = "Select DISTINCT o.OrderId, o.OrderDate, o.ClientId, c.ClientName, c.ClientAddress,p.ProductId, p.ProductName, p.ProductPrice\r\nfrom Orders o\r\nJOIN OrderIdtoProductId j ON o.OrderId = j.OrderId\r\nJOIN Products p ON j.ProductId = p.ProductId\r\nJOIN Clients c ON o.ClientId = c.ClientId";
        }
        public IEnumerable<DbOrder> GetOrders()
        {
            _msSqlProvider.ExecuteQuery(out DataTable table, query);
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        public IEnumerable<DbOrder> GetOrders2()
        {
            _msSqlProvider2.ExecuteQuery(out DataTable table, query);
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        private DbOrder RowToModel(DataRow row) =>
            new DbOrder
            {
                OrderId = row.GetValueAsInt("OrderId"),
                OrderDate = row.GetValueAsDateTime("OrderDate"),
                ClientId = row.GetValueAsInt("ClientId"),
                ClientAddress = row.GetValueAsString("ClientAddress"),
                ClientName = row.GetValueAsString("ClientName"),
                ProductId = row.GetValueAsInt("ProductId"),
                ProductName = row.GetValueAsString("ProductName"),
                ProductPrice = row.GetValueAsDouble("ProductPrice")
            };
    }
}
