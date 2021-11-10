using EshopSolution.Extensions.Enums;

namespace EshopSolution.Extensions.BaseAPI
{
    public abstract class PaginatorRequest
    {
        public int PageIndex { get; set; } = DefaultValue.PageIndex;
        public int PageSize { get; set; } = DefaultValue.PageSize;
        public string SortBy { get; set; } = DefaultValue.SortBy;
        public string SortDirection { get; set; } = ESortDirection.Descending.Name;
    }
}
