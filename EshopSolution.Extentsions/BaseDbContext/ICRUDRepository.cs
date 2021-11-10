using System;
using System.Threading.Tasks;

namespace EshopSolution.Extensions.BaseDbContext
{
    public interface ICRUDRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        Task<T> GetByIdAsync(Guid id);
        T GetById(Guid id);
        void Remove(T entity);
    }
}
