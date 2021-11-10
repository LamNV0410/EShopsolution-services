using Dapper;
using EshopSolution.Extensions.BaseAPI;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using SystemService.Domain.DomainModel;
using SystemService.Domain.DTOs;
using SystemService.Domain.IQueries;

namespace SystemService.Infrastructure.Queries
{
    public class UserTypeQueries : IUserTypeQueries
    {
        private readonly string _connectionString;
        public UserTypeQueries(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<UserTypeDTO> GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
SELECT 
Id,
TypeName
FROM SystemService.UserTypes
WHERE Id = @id";
                return await connection.QueryFirstOrDefaultAsync<UserTypeDTO>(sql, new { id = id });
            }
        }

        public async Task<IPaginatorResponse<UserTypeDTO>> GetUserTypesPaging(
            string keyword,
            DateTime? createdDate,
            Guid? userId,
            int page,
            int size,
            string sortField,
            string sortDirection,
            bool getCount = true)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
SELECT 
UT.Id AS Id,
UT.TypeName,
UT.CreatedDate,
UTR.Id AS UserTypeRoleId,
UTR.UserTypeRoleName
FROM 
SystemService.UserTypes UT
JOIN SystemService.UserTypeRoles UTR
ON UT.UserTypeRoleId = UTR.Id
");
                StringBuilder sqlWhere = new StringBuilder();
                if (!string.IsNullOrEmpty(keyword))
                {
                    if (sqlWhere.Length > 0)
                    {
                        sqlWhere.Append(" AND ");
                    }
                    sqlWhere.Append(" UT.TypeName LIKE @keyword ");
                    parameters.Add("@keyword", keyword);
                }

                if (createdDate != null)
                {
                    if (sqlWhere.Length > 0)
                    {
                        sqlWhere.Append(" AND ");
                    }
                    sqlWhere.Append(" UT.CreatedDate >= @createdDate");
                    parameters.Add("@createdDate", createdDate);
                }

                if (userId != null)
                {
                    if (sqlWhere.Length > 0)
                    {
                        sqlWhere.Append(" AND ");
                    }
                    sqlWhere.Append(" UT.CreatedBy >= @userId");
                    parameters.Add("@userId", userId);
                }

                StringBuilder orderBy = new StringBuilder();
                orderBy.Append(" ORDER BY ");
                if (sortField == "CRE")
                {
                    orderBy.Append(" UT.CreatedDate ");
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
                var users = await connection.QueryAsync<UserTypeDTO>(sql, parameters, commandType: CommandType.Text);
                var count = 0;
                if (getCount)
                {
                    StringBuilder sqlCount = new StringBuilder();
                    sqlCount.Append(@"
SELECT 
COUNT(*)
FROM 
SystemService.UserTypes UT
JOIN SystemService.UserTypeRoles UTR
ON UT.UserTypeRoleId = UTR.Id
 ");
                    sqlCount.Append(sqlWhere).ToString();
                    count = await connection
                        .QueryFirstOrDefaultAsync<int>(sqlCount.ToString(), parameters, commandType: CommandType.Text);
                }

                return new PaginatorResponse<UserTypeDTO>()
                {
                    Items = users,
                    TotalItems = count
                };
            }
        }

        public async Task<IEnumerable<UserTypeRole>> GetUserTypeRolesSelect()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
SELECT 
*
FROM SystemService.UserTypeRoles";
                return await connection.QueryAsync<UserTypeRole>(sql);
            }
        }

        public async Task<IEnumerable<UserType>> GetUsserTypeSelect()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @"
SELECT 
*
FROM SystemService.UserTypes";

                return await connection.QueryAsync<UserType>(sql);
            }
        }
    }
}
