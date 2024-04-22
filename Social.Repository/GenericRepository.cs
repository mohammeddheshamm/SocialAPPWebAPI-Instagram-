using Microsoft.EntityFrameworkCore;
using Social.Core.Entity;
using Social.Core.Repositories;
using Social.Core.Specifications;
using Social.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity 
    {
        private readonly InstagramDbContext _context;

        public GenericRepository(InstagramDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);
        
        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);
        
        public async Task<IReadOnlyList<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }

    }
}
