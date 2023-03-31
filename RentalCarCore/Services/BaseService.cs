using CarRentalCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        protected readonly IBaseDataAcces<T> _baseDataAcces;
        public BaseService(IBaseDataAcces<T> baseDataAcces)
        {
            _baseDataAcces = baseDataAcces;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _baseDataAcces.GetAll();
        }


        public virtual async Task<T> Get(int id)
        {
            return await _baseDataAcces.Get(id);
        }
        public virtual async Task<T> Add(T entity)
        {
            var newEntity= await _baseDataAcces.Add(entity);
            await _baseDataAcces.SaveAsync();
            return newEntity;
        }
       
    }
}
