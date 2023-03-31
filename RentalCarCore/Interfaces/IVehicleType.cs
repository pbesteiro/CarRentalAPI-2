using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetAll();              
        Task<VehicleType> Get(int id);
        Task<VehicleType> Add(VehicleType v);
        Task<VehicleType> GetByName(string name);
    }
}
