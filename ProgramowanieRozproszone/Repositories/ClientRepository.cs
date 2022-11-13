using Microsoft.Extensions.Configuration;
using ProgramowanieRozproszone.Helpers;
using ProgramowanieRozproszone.Models;
using System.Data;

namespace ProgramowanieRozproszone.Repositories
{
    public class ClientRepository
    {
        private readonly MsSqlProvider _msSqlProvider;
        private readonly MsSqlProvider _msSqlProvider2;
        private IConfiguration _configuration;
        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _msSqlProvider = new MsSqlProvider(_configuration.GetValue<string>("ConnectionStrings:connectionString1"));
            _msSqlProvider2 = new MsSqlProvider(_configuration.GetValue<string>("ConnectionStrings:connectionString2"));
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
