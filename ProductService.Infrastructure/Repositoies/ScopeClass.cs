using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.DBContext;
using System;

namespace ProductService.Infrastructure.Repositoies
{
    public class ScopeClass : IScopeClass
    {
        private readonly ProductDbContext _context;
        public ScopeClass(ProductDbContext context)
        {
            _context = context;
        }
        public ProductDbContext Context => _context;
    }

    public interface IScopeClass
    {
        public ProductDbContext Context { get; }
    }
}
