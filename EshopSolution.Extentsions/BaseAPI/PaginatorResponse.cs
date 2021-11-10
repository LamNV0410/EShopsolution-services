using System.Collections.Generic;

namespace EshopSolution.Extensions.BaseAPI
{
    public class PaginatorResponse<T> : IPaginatorResponse<T>
    {
        public PaginatorResponse()
        {
        }
        public int? TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
