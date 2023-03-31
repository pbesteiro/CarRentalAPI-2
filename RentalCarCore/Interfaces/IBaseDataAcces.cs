using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface IBaseDataAcces<T>
    {
        Task<T> Add(T entity);
        void Delete(T entity);
        Task<T> Get(int id, params string[] including);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, params string[] including);
        void Update(T entity);
        void Save();

        Task SaveAsync();
    }
}
