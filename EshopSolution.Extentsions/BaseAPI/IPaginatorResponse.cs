using System.Collections.Generic;

namespace EshopSolution.Extensions.BaseAPI
{
    public interface IPaginatorResponse<T>
    {
        int? TotalItems { get; set; }
        IEnumerable<T> Items { get; set; }
    }
}
