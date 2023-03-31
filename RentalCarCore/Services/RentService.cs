using CarRentalCore.Exceptions;
using CarRentalCore.Interfaces;
using CarRentalCore.Requests;
using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class RentService : BaseService<Rental>, IRentService
    {
        private readonly IVehicleService _vehicleService=null;
        private readonly ICustomerService _customerService = null;
        private readonly IPriceService _priceService = null;
        public RentService(IBaseDataAcces<Rental> baseDataAcces, IVehicleService vehicleService, ICustomerService customerService, IPriceService priceService) : base(baseDataAcces)
        {
            _vehicleService = vehicleService;
            _customerService = customerService;
            _priceService = priceService;
        }

        /// <summary>
        /// Gets the rents of specified customer
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        public async Task<Rental> GetByIdCustomer(int idCustomer)
        {
            var types = await _baseDataAcces.GetAll(null, "Vehicle", "Customer");
            var type = types.FirstOrDefault(t => t.CustomerID == idCustomer);
            return type;
        }

        public override async Task<IEnumerable<Rental>> GetAll()
        {
            var types = await _baseDataAcces.GetAll(null, "Vehicle", "Vehicle.Model", "Vehicle.Model.Brand", "Vehicle.Model.VehicleType", "Customer");
            return types;
        }

        public override async Task<Rental> Add(Rental entity)
        {
            var vehicle = await _vehicleService.Get(entity.VehicleID);
            if (vehicle == null)
                throw new BussinessException("Vehicle not found");

            var customer = await _customerService.Get(entity.CustomerID);
            if (customer == null)
                throw new BussinessException("Customer not found");

            AvailableVehiclesRequest av = new AvailableVehiclesRequest { DateFrom = entity.DateFrom, DateTo = entity.DateTo, VehicleTypeId = vehicle.Model.VehicleTypeID };
            var avaliables = await _vehicleService.GetAvailables(av);
            if (!avaliables.Any(v => v.Id == entity.VehicleID))
                throw new BussinessException("Vehicle is not avaliable to rent in specified range");

            var pricePerDay = await _priceService.GetPrice(entity.DateFrom, vehicle.ModelID);
            if (pricePerDay == 0)
                throw new BussinessException("Vehicle is not priced in specified range");

            double totalDays = (entity.DateTo - entity.DateFrom).TotalDays;

            entity.Price = totalDays * pricePerDay;
            entity.Active = true;
            var newEntity = await _baseDataAcces.Add(entity);
            await _baseDataAcces.SaveAsync();
            return newEntity;
        }

        public async Task Delete(int rentId)
        {
            var existentRent = await _baseDataAcces.Get(rentId);
            if (existentRent == null)
                throw new BussinessException("Rent not found");

            existentRent.Active = false;
            _baseDataAcces.Update(existentRent);
            _baseDataAcces.Save();
        }

    }
}
