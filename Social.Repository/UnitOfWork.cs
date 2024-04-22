using Social.Core.Entity;
using Social.Core.Repositories;
using Social.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly InstagramDbContext _context;

        public UnitOfWork(InstagramDbContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
            => await _context.SaveChangesAsync();
        

        public void Dispose()
           => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.Contains(type))
            {
                var repository = new GenericRepository<TEntity>(_context);
                _repositories.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
