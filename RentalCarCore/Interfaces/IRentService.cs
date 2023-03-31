using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface IRentService
    {
        Task Delete(int rentId);
        Task<IEnumerable<Rental>> GetAll();
        Task<Rental> Get(int id);
        Task<Rental> Add(Rental v);
        Task<Rental> GetByIdCustomer(int idCustomer);
    }
}
