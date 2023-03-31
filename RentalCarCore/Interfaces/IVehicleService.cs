using CarRentalCore.Requests;
using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAvailables(AvailableVehiclesRequest request);
        Task<IEnumerable<Vehicle>> GetAll();
        Task<Vehicle> Get(int id);
        Task<Vehicle> Add(Vehicle v);
        Task<Vehicle> GetByDomain(string name);
        Task Delete(int id);
    }
}