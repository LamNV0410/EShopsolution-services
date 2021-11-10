using Dapper;
using EshopSolution.Extensions.BaseAPI;
using Microsoft.Data.SqlClient;
using ProductService.Domain.DomainModel.ProductApp;
using ProductService.Domain.IQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly string _connectionString;
        public ProductQueries(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IPaginatorResponse<Product>> GetProducts(string keyword, string sortBy, string sortDirection, int pageIndex, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = new StringBuilder();
                DynamicParameters sqlParameter = new DynamicParameters();
                sql.Append(" SELECT * FROM ProductService.Products WHERE IsActive = 0 ");

                StringBuilder sqlWhere = new StringBuilder();

                if (!string.IsNullOrEmpty(keyword))
                {
                    sqlWhere.Append(" AND [Name] Like @keyword ");
                    sqlParameter.Add("keyword", keyword, System.Data.DbType.String);
                }

                sql.Append(sqlWhere);
                StringBuilder sqlOrder = new StringBuilder();
                switch (sortBy)
                {
                    case "CRE":
                        sqlOrder.Append(" ORDER BY CreatedDate DESC");
                        break;
                    default:
                        break;
                }

                //sqlParameter.Add("sortBy", sortBy, System.Data.DbType.String);
                //sqlParameter.Add("sortDirection", sortDirection, System.Data.DbType.String);

                sqlOrder.Append(" OFFSET @pageIndex ROWS ");
                sqlParameter.Add("pageIndex", pageIndex * pageSize, System.Data.DbType.Int32);
                sqlOrder.Append(" FETCH NEXT @pageSize ROWS ONLY; ");
                sqlParameter.Add("pageSize", pageSize, System.Data.DbType.Int32);
                sql.Append(sqlOrder);

                var products = await connection.QueryAsync<Product>(sql.ToString(), sqlParameter);
                sql.Clear();
                sql.Append(" SELECT COUNT(*) FROM ProductService.Products ");
                sql.Append(sqlWhere);
                //sql.Append(sqlOrder);

                var count = await connection.QueryFirstOrDefaultAsync<int>(sql.ToString(), sqlParameter);

                var result = new PaginatorResponse<Product>()
                {
                    Items = products,
                    TotalItems = count
                };

                return result;
            }
        }
    }
}
