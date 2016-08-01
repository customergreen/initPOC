using CustomerGreen.Core.Data;
using CustomerGreen.Core.Data.Repositories;
using CustomerGreen.Core.Entities;
using CustomerGreen.Data.Repositories;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace CustomerGreen.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : IEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(T).Name;
            
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T>)_repositories[type];
            }
            
            var repositoryType = typeof(BaseRepository<>);
            
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context));
            
            return (IRepository<T>)_repositories[type];
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public int Commit()
        {
            return _context.Commit();
        }

        public Task<int> CommitAsync()
        {
            return _context.CommitAsync();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                foreach (IDisposable repository in _repositories.Values)
                {
                    repository.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
