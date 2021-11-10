using EshopSolution.Extensions.BaseAPI;
using MediatR;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.DTOs;

namespace ProductService.API.Application.CategoryApp.Queries
{
    public class GetCategoriesQuery : PaginatorRequest,IRequest<IPaginatorResponse<Category>>
    {
        public string Keyword { get; set; }
    }
}
