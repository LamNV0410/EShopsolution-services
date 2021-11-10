using EshopSolution.Extensions.BaseDbContext;
using SystemService.Domain.DomainModel;

namespace SystemService.Domain.IRepositories
{
    public interface IUserTypeRepository : ICRUDRepository<UserType>,IRepository<UserType>
    {

    }
}
