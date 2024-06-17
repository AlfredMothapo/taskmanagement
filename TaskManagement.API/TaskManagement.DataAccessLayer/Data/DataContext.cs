using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace TaskManagement.DataAccessLayer
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}
