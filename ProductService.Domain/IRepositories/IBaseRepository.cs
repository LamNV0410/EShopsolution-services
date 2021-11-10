using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Domain.IRepositories
{
    public interface IBaseRepository : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
