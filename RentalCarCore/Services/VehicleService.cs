using CarRentalCore.Exceptions;
using CarRentalCore.Interfaces;
using CarRentalCore.Requests;
using RentalCarCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class VehicleService : BaseService<Vehicle>, IVehicleService
    {
        public VehicleService(IBaseDataAcces<Vehicle> baseDataAcces) : base(baseDataAcces)
        {
        }

        /// <summary>
        /// Get a car with the specified domain
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<Vehicle> GetByDomain(string domain)
        {
            var types = await _baseDataAcces.GetAll();
            var type = types.FirstOrDefault(t => t.Domain == domain);
            return type;
        }

        public async Task<IEnumerable<Vehicle>> GetAvailables(AvailableVehiclesRequest request)
        {
            if(request.DateFrom > request.DateTo)
                throw new BussinessException("Date To have to be greathen than Date From");


            var vechiles = await _baseDataAcces.GetAll(filter: x=> x.Active, "Model", "User", "Model.Brand", "Model.VehicleType","Rentals");
            vechiles = vechiles.Where(r => !r.Rentals.Any(_ => (request.DateFrom >= _.DateFrom &&  request.DateFrom <= _.DateTo) || ( request.DateTo >= _.DateFrom && request.DateTo <= _.DateTo) || (request.DateFrom <= _.DateFrom && request.DateTo >= _.DateFrom) || (request.DateFrom <= _.DateTo && request.DateTo >= _.DateTo)));
                      
            if (request.VehicleTypeId.HasValue)
            {
                vechiles = vechiles.Where(v => v.Model.VehicleTypeID == request.VehicleTypeId);
            }
            
            return vechiles;
        }


        public override async Task<IEnumerable<Vehicle>> GetAll()
        {
            var types = await _baseDataAcces.GetAll(null,"Model", "User", "Model.Brand", "Model.VehicleType");
            return types;
        }

        public override async Task<Vehicle> Get(int id)
        {
            var type = await _baseDataAcces.Get(id, "Model", "User", "Model.Brand", "Model.VehicleType");
            return type;
        }

        public override async Task<Vehicle> Add(Vehicle entity)
        {
            var existentVehicle = await GetByDomain(entity.Domain);
            if (existentVehicle != null)
                throw new BussinessException("Vehicle with same domain already exists");

            entity.UserIDCreation = 1;
            entity.Active = true;
            entity.DateCreation = DateTime.Now;
            var newEntity = await _baseDataAcces.Add(entity);
            await _baseDataAcces.SaveAsync();
            return newEntity;
        }

        public async Task Delete(int id)
        {
            var existentVehicle = await _baseDataAcces.Get(id);
            if (existentVehicle == null)
                throw new BussinessException("vehicle not found");

            existentVehicle.Active = false;
            _baseDataAcces.Update(existentVehicle);
            _baseDataAcces.Save();
        }

    }
}
