using System;
using System.Threading;
using System.Threading.Tasks;
using SystemService.Domain.DomainModel;
using SystemService.Domain.IRepositories;
using SystemService.Infrastructure.DBContext;

namespace SystemService.Infrastructure.Repositoies
{
    public class AvatarRepository : IAvatarRepository
    {
        private SystemDBContext _context;
        public AvatarRepository(SystemDBContext context)
        {
            _context = context;
        }
        public Avatar Create(Avatar entity)
        {
            return _context.Add(entity).Entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Avatar> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Avatar> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Avatar entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Avatar Update(Avatar entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity;
        }
    }
}
