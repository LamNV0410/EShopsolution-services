using Authentication.API.Application.Queries;
using Dapper;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Authentication.API.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly string _connectionString;

        public UserQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UserInfo> GetUsersAsync(string userName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@userName", userName, DbType.String);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@" 
SELECT
Id,
Email,
FirstName,
LastName,
Password,
Salt,
UserTypeRoleId
FROM SystemService.Users
WHERE userName = @userName
");
                string query = sb.ToString();

                var result = await connection.QueryFirstOrDefaultAsync<UserInfo>(query, parameters);
                return result;
            }
        }
    }

    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Format("{0} {1}", LastName, FirstName);
        public string Password { get; set; }
        public string Salt { get; set; }
        public Guid UserTypeRole { get; set; }
    }
}
