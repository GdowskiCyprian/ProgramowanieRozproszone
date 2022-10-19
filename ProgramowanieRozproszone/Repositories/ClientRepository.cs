using ProgramowanieRozproszone.Helpers;
using ProgramowanieRozproszone.Models;
using System.Data;

namespace ProgramowanieRozproszone.Repositories
{
    public class ClientRepository
    {
        private readonly MsSqlProvider _msSqlProvider;
        private readonly MsSqlProvider _msSqlProvider2;
        private string _connectionString;
        private string _connectionString2;
        public ClientRepository()
        {
            _connectionString = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone1;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _connectionString2 = "Server=tcp:programowanierozproszone.database.windows.net,1433;Initial Catalog=programowanierozproszone2;Persist Security Info=False;User ID=ProgramowanieRozproszone;Password=zaq1@WSX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            _msSqlProvider = new MsSqlProvider(_connectionString);
            _msSqlProvider2 = new MsSqlProvider(_connectionString2);
        }

        public IEnumerable<Client> GetClients()
        {
            _msSqlProvider.ExecuteQuery(out DataTable table, "Select * from Clients");
            foreach(DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        public IEnumerable<Client> GetClients2()
        {
            _msSqlProvider2.ExecuteQuery(out DataTable table, "Select * from Clients");
            foreach (DataRow row in table.Rows)
            {
                yield return RowToModel(row);
            }
        }
        private Client RowToModel(DataRow row) =>
            new Client
            {
                ClientId = row.GetValueAsInt("ClientId"),
                ClientAddress = row.GetValueAsString("ClientAddress"),
                ClientName = row.GetValueAsString("ClientName")
            };
    }
}
