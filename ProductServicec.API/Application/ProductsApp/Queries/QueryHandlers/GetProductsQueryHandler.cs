using EshopSolution.Extensions.BaseAPI;
using MediatR;
using ProductService.API.Application.ProductsApp.Queries.QueryModels;
using ProductService.Domain.DomainModel.ProductApp;
using ProductService.Domain.IQueries;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.ProductsApp.Queries.QueryHandlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IPaginatorResponse<Product>>
    {
        private readonly IProductQueries _productQueries;
        public GetProductsQueryHandler(IProductQueries productQueries)
        {
            _productQueries = productQueries;
        }
        public async Task<IPaginatorResponse<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IPaginatorResponse<Product> products = await _productQueries.GetProducts(request.Keyword, request.SortBy, request.SortDirection, request.PageIndex, request.PageSize);
            return products;
        }
    }
}
