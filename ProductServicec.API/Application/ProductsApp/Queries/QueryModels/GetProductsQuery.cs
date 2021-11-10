using EshopSolution.Extensions.BaseAPI;
using MediatR;
using ProductService.Domain.DomainModel.ProductApp;

namespace ProductService.API.Application.ProductsApp.Queries.QueryModels
{
    public class GetProductsQuery : PaginatorRequest, IRequest<IPaginatorResponse<Product>>
    {
        public string Keyword { get; set; }
    }
}
