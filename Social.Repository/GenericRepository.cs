using Microsoft.EntityFrameworkCore;
using Social.Core.Entity;
using Social.Core.Repositories;
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
        
        public async Task<IReadOnlyList<T>> GetAll()
            => await _context.Set<T>().ToListAsync();


        public async Task<T> GetById(int id)
            => await _context.Set<T>().FindAsync(id);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);
        
    }
}
