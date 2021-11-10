using EshopSolution.Extensions.BaseDbContext;
using SystemService.Domain.DomainModel;

namespace SystemService.Domain.IRepositories
{
    public interface IAvatarRepository : ICRUDRepository<Avatar>,IBaseRepository
    {
    }
}
