using Npgsql;
using TaskManagement.BL.Models;
using Dapper;


namespace TaskManagement.BL.Repositories.TaskRepository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            const string query = "SELECT * FROM \"Task\"";
            using var connection = CreateConnection();
            return await connection.QueryAsync<TaskModel>(query);
        }

        public async Task<TaskModel> GetByIdAsync(Guid id)
        {
            const string query = "SELECT * FROM \"Task\" WHERE \"Id\" = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<TaskModel>(query, new { Id = id });
        }

        public async Task AddAsync(TaskModel task)
        {
            task.Id = Guid.NewGuid();
            const string query = "INSERT INTO \"Task\" (\"Id\", \"Title\", \"Description\") VALUES (@Id, @Title, @Description)";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(query, task);
        }

        public async Task UpdateAsync(TaskModel task)
        {
            const string query = "UPDATE \"Task\" SET \"Title\" = @Title, \"Description\" = @Description WHERE \"Id\" = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(query, task);
        }

        public async Task DeleteAsync(Guid id)
        {
            const string query = "DELETE FROM \"Task\" WHERE \"Id\" = @Id";
            using var connection = CreateConnection();
            await connection.ExecuteAsync(query, new { Id = id });
        }

    }
}
