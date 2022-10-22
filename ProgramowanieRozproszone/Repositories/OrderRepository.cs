using ProgramowanieRozproszone.Helpers;
using ProgramowanieRozproszone.Models;
using ProgramowanieRozproszone.Services;
using System.Data;

namespace ProgramowanieRozproszone.Repositories
{
    public class OrderRepository
    {
        private readonly MsSqlProvider _msSqlProvider;
        private readonly MsSqlProvider _msSqlProvider2;
        private string _connectionString;
        private string _connectionString2;
        public OrderRepository()
        {
            _connectionString = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone1;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _connectionString2 = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone2;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _msSqlProvider = new MsSqlProvider(_connectionString);
            _msSqlProvider2 = new MsSqlProvider(_connectionString2);
        }
        public IEnumerable<DbOrder> GetOrders()
        {
            _msSqlProvider.ExecuteQuery(out DataTable table, "Select * from Orders");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        public IEnumerable<DbOrder> GetOrders2()
        {
            _msSqlProvider2.ExecuteQuery(out DataTable table, "Select * from Orders");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        public IEnumerable<BdOrderToProduct> GetOrderProductMap()
        {
            _msSqlProvider.ExecuteQuery(out DataTable table, "Select * from OrderIdtoProductId");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModelMap(row);
            }
        }
        public IEnumerable<BdOrderToProduct> GetOrderProductMap2()
        {
            _msSqlProvider2.ExecuteQuery(out DataTable table, "Select * from OrderIdtoProductId");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModelMap(row);
            }
        }
        public void DeleteOrder(int OrderId)
        {
            _msSqlProvider.ExecuteNonQuery("Delete from Orders Where OrderId = " + OrderId.ToString());
        }
        public void DeleteOrder2(int OrderId)
        {
            _msSqlProvider2.ExecuteNonQuery("Delete from Orders Where OrderId = " + OrderId.ToString());
        }
        public void UpdateOrder(Order order)
        {
            _msSqlProvider.ExecuteNonQuery("UPDATE Orders SET OrderDate = " + order.OrderDate +
                " ClientId = " + order.Client.ClientId + " where OrderId = " + order.OrderId );
        }
        public void UpdateOrder2(Order order)
        {
            _msSqlProvider2.ExecuteNonQuery("UPDATE Orders SET OrderDate = " + order.OrderDate +
                " ClientId = " + order.Client.ClientId + " where OrderId = " + order.OrderId);
        }
        public void InsertOrder(Order order)
        {
            _msSqlProvider.ExecuteNonQuery("INSERT INTO Orders VALUES (" + order.OrderId + " , " + order.OrderDate.Date.ToString() + " , " + order.Client.ClientId+")");
            foreach(var product in order.Products)
            {
                _msSqlProvider.ExecuteNonQuery("INSERT INTO OrderIdtoProductId VALUES ( " + order.OrderId + " , " + product.ProductId + ")");
            }
        }
        public void InsertOrder2(Order order)
        {
            _msSqlProvider2.ExecuteNonQuery("INSERT INTO Orders VALUES (" + order.OrderId + " , " + order.OrderDate.Date.ToString() + " , " + order.Client.ClientId + ")");
            foreach (var product in order.Products)
            {
                _msSqlProvider2.ExecuteNonQuery("INSERT INTO OrderIdtoProductId VALUES ( " + order.OrderId + " , " + product.ProductId + ")");
            }
        }
        public int maxId()
        {
            _msSqlProvider.ExecuteQuery(out DataTable table, "Select MAX(OrderId) as max from Orders");
            return table.Rows[0].GetValueAsInt("max");
        }
        public int maxId2()
        {
            _msSqlProvider2.ExecuteQuery(out DataTable table, "Select MAX(OrderId) as max from Orders");
            return table.Rows[0].GetValueAsInt("max");
        }
        private DbOrder RowToModel(DataRow row) =>
            new DbOrder
            {
                OrderId = row.GetValueAsInt("OrderId"),
                OrderDate = row.GetValueAsDateTime("OrderDate"),
                ClientId = row.GetValueAsInt("ClientId")
            };
        private BdOrderToProduct RowToModelMap(DataRow row) =>
            new BdOrderToProduct
            {
                OrderId = row.GetValueAsInt("OrderId"),
                ProductId = row.GetValueAsInt("ProductId")
            };
    }
}
