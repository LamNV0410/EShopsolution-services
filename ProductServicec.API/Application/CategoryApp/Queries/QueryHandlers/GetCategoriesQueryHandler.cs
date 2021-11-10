using EshopSolution.Extensions.BaseAPI;
using MediatR;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.IQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.API.Application.CategoryApp.Queries.QueryHandlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IPaginatorResponse<Category>>
    {
        private readonly ICategoriesQueries _categoriesQueries;
        public GetCategoriesQueryHandler(ICategoriesQueries categoriesQueries)
        {
            _categoriesQueries = categoriesQueries;
        }
        public Task<IPaginatorResponse<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _categoriesQueries.GetAll(request.Keyword, request.SortBy, request.SortDirection, request.PageIndex, request.PageSize);
        }
    }
}
