using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        public void Add(T obj) => _contexto.Add(obj);
        public async Task<T> GetByIdAsync(string id) => await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        public void Remove(Guid id) => DbSet.Remove(DbSet.Find(id.ToString()));
        public Task<int> SaveChangesAsync() => _contexto.SaveChangesAsync();
        public async Task<List<T>>GetAllAsync() => await DbSet.ToListAsync();
        public void UpDate(T entity) => DbSet.Update(entity);
        public void Dispose() => _contexto.Dispose();
        
    }
}
