using CustomerGreen.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerGreen.Core.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        Task<List<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(int id);

        void Add(T entity);

        void Update(T entity);
        
        void Delete(T entity);
    }
}
