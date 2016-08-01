using CustomerGreen.Core.Data.Repositories;
using CustomerGreen.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CustomerGreen.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : IEntity;
        
        void BeginTransaction();
        
        int Commit();
        
        Task<int> CommitAsync();

        void Rollback();

        void Dispose(bool disposing);

    }
}
