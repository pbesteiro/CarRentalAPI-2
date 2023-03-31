using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface IBaseService<T>
    {
        Task<T> Add(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}