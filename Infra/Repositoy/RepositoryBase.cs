using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositoy
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : Entity
    {
        protected EntityContext _contexto;
        protected DbSet<T> DbSet;
        public RepositoryBase(EntityContext contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<T>();
        }

        public void Add(T obj)
        {
            _contexto.Add(obj);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            
        }

        public async void Remove(Guid id)
        {
            var test = await GetByIdAsync(id);
            DbSet.Remove(test);
        }

        public Task<int> SaveChangesAsync()
        {
            return _contexto.SaveChangesAsync();
        }

        public async Task<List<T>>GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public void UpDate(T entity)
        {
            DbSet.Update(entity);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
