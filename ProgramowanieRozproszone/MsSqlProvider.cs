

using System.Data;
using System.Data.SqlClient;

namespace ProgramowanieRozproszone
{
    public class MsSqlProvider
    {
        private string _connectionString;

        public MsSqlProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            using (var dataAdapter = new SqlDataAdapter(command))
            {
                try
                {
                    command.CommandTimeout = 1800;
                    command.CommandText = query;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void ExecuteQuery(out DataTable dataTable, string query)
        {
            dataTable = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            using (var dataAdapter = new SqlDataAdapter(command))
            {
                try
                {
                    command.CommandTimeout = 1800;
                    command.CommandText = query;
                    if(connection.State != ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    dataAdapter.Fill(dataTable);
                }
                finally 
                { 
                    connection.Close(); 
                }
            }
        }
    }
}
