using Dapper;
using EshopSolution.Extensions.BaseAPI;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using SystemService.Domain.DTOs;
using SystemService.Domain.IQueries;

namespace SystemService.Infrastructure.Queries
{
    public class UsersQueries : IUserQueries
    {
        private readonly string _connectionString;
        public UsersQueries(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<UsersDTO> GetByIdAsync(Guid id)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
SELECT 
U.Id,
U.FirstName,
U.LastName,
U.UserName,
U.Address,
U.PhoneNumber,
U.Email,
U.Gender,
UT.Id AS UserTypeId,
UT.TypeName AS UserTypeName
FROM SystemService.Users U
LEFT JOIN SystemService.UserTypes UT
ON U.UserTypeId = UT.Id
WHERE U.Id = @Id
";
                return await connection
                        .QueryFirstOrDefaultAsync<UsersDTO>(sql, new { Id = id }, commandType: CommandType.Text);
            }
        }

        public async Task<IPaginatorResponse<UsersDTO>> GetUsersPaging(
            string keyword,
            DateTime? createdDate,
            Guid? userId,
            int page,
            int size,
            string sortField,
            string sortDirection,
            bool getCount = true
            )
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
SELECT 
U.Id,
U.UserName,
U.LastName,
U.FirstName,
U.Address,
U.PhoneNumber,
U.Gender,
U.UserTypeId,
UT.TypeName AS UserTypeName,
U.Email,
UT.TypeName
FROM SystemService.Users AS U
JOIN SystemService.UserTypes AS UT
ON U.UserTypeId = UT.Id
");
                StringBuilder sqlWhere = new StringBuilder();
                if (!string.IsNullOrEmpty(keyword))
                {
                    if (sqlWhere.Length > 0)
                    {
                        sqlWhere.Append(" AND ");
                    }
                    sqlWhere.Append(" TRIM(CONCAT(U.FirstName,' ', U.LastName)) LIKE @keyword ");
                    parameters.Add("@keyword", keyword);
                }

                if (createdDate != null)
                {
                    if (sqlWhere.Length > 0)
                    {
                        sqlWhere.Append(" AND ");
                    }
                    sqlWhere.Append(" U.CreatedDate >= @createdDate");
                    parameters.Add("@createdDate", createdDate);
                }

                if (userId != null)
                {
                    if (sqlWhere.Length > 0)
                    {
                        sqlWhere.Append(" AND ");
                    }
                    sqlWhere.Append(" U.CreatedBy >= @userId");
                    parameters.Add("@userId", userId);
                }

                StringBuilder orderBy = new StringBuilder();
                orderBy.Append(" ORDER BY ");
                if (sortField == "CRE")
                {
                    orderBy.Append(" U.CreatedDate ");
                }

                if (sortDirection == "DESC")
                {
                    orderBy.Append(" DESC ");
                }

                if (sqlWhere.Length > 0)
                    sqlWhere.Insert(0, " WHERE ");

                string sql = sb.Append(sqlWhere).Append(orderBy).ToString();
                sql += "OFFSET @page * @size ROWS FETCH NEXT @size ROWS ONLY";
                parameters.Add("@page", page);
                parameters.Add("@size", size);
                var users = await connection.QueryAsync<UsersDTO>(sql, parameters, commandType: CommandType.Text);
                var count = 0;
                if (getCount)
                {
                    StringBuilder sqlCount = new StringBuilder();
                    sqlCount.Append(@"
SELECT COUNT(*) 
FROM SystemService.Users AS U
JOIN SystemService.UserTypes AS UT
    ON U.UserTypeId = UT.Id
 ");
                    sqlCount.Append(sqlWhere).ToString();
                    count = await connection
                        .QueryFirstOrDefaultAsync<int>(sqlCount.ToString(), parameters, commandType: CommandType.Text);
                }

                return new PaginatorResponse<UsersDTO>()
                {
                    Items = users,
                    TotalItems = count
                };
            }
        }

        public Task<int> GetUsersPaging_TotalCount(string keyword, DateTime? createdDate, Guid userId, int page, int size, string sortField, string sortDirection)
        {
            throw new NotImplementedException();
        }
    }
}
