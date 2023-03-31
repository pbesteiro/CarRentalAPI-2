using CarRentalCore.Exceptions;
using CarRentalCore.Interfaces;
using CarRentalCore.Services;
using RentalCarCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCarCore.Services
{
    public class VehicleTypeService : BaseService<VehicleType>,  IVehicleTypeService
    {
       
        public VehicleTypeService(IBaseDataAcces<VehicleType> baseDataAcces):base(baseDataAcces)
        {
        }

        /// <summary>
        /// get a vehicle type with the specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<VehicleType> GetByName(string name)
        {
            var types=await _baseDataAcces.GetAll();
            var type = types.FirstOrDefault(t => t.Description == name);
            return type;
        }

        public override async Task<VehicleType> Add(VehicleType type)
        {
            var existentType = await GetByName(type.Description);
            if (existentType != null)
                throw new BussinessException("Vehicle type already exists");

            type.Active = true;            
            await _baseDataAcces.Add(type);

            return type;
        }

        



    }
}
