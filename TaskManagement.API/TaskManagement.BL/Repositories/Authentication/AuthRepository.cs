using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using TaskManagement.BL.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagement.BL.Repositories.Authentication
{
    public class AuthRepository: IAuthRepository
    {
        private readonly string _connectionString;
        private IDbConnection _dbConnection;

        public AuthRepository(string connectionString)
        {
            _connectionString = connectionString;
            _dbConnection = CreateConnection();
        }

        private NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task RegisterAsync(UserModel UserModel)
        {
            UserModel.Id = Guid.NewGuid();
            const string query = @"
            INSERT INTO ""User"" (""Id"", ""FirstName"", ""LastName"", ""EmailAddress"", ""Password"")
            VALUES (@Id, @FirstName, @LastName, @EmailAddress, @Password)";

            await _dbConnection.ExecuteAsync(query, UserModel);
        }

        public async Task<UserModel> LoginAsync(string emailAddress, string password)
        {
            const string query = @"
            SELECT * FROM ""User"" 
            WHERE ""EmailAddress"" = @EmailAddress AND ""Password"" = @Password";

            return await _dbConnection.QueryFirstOrDefaultAsync<UserModel>(query, new { EmailAddress = emailAddress, Password = password });
        }

        public async Task DeactivateUserAsync(Guid UserModelId)
        {
            using var connection = CreateConnection();
            const string query = @"
            UPDATE ""User"" 
            SET ""IsActive"" = FALSE 
            WHERE ""Id"" = @UserModelId";

            await _dbConnection.ExecuteAsync(query, new { UserModelId = UserModelId });
        }
    }
}
