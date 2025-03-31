using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdp.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Create(T entity);
        void Remove(T entity);
        void Update(T entity);
        T? GetById(int id);
        List<T> GetAll();

        IQueryable<T> GetQueryable();
    }
}