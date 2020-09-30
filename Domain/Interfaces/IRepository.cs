using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
         where T : Entity
    {
        void Add(T obj);
        Task<int> SaveChangesAsync();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        void Remove(Guid id);
        void UpDate(T entity);
    }
}
