using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface ICustomerService
    {
        Task Delete(int customerId);
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Get(int id);
        Task<Customer> Add(Customer v);
        Task<Customer> GetByIdCard(string name);
    }
}
