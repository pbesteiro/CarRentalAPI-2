using CarRentalCore.Exceptions;
using CarRentalCore.Interfaces;
using RentalCarCore.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class CustomerService : BaseService<Customer>,ICustomerService
    {
        public CustomerService(IBaseDataAcces<Customer> baseDataAcces) : base(baseDataAcces)
        {
        }

        /// <summary>
        /// Get a customer with the specified idCard
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<Customer> GetByIdCard(string idCard)
        {
            var types = await _baseDataAcces.GetAll();
            var type = types.FirstOrDefault(t => t.IdCard == idCard);
            return type;
        }

        

        public override async Task<Customer> Add(Customer entity)
        {
            var existentCustomer = await GetByIdCard(entity.IdCard);
            if (existentCustomer != null)
                throw new BussinessException("Customer exists");

            entity.Active = true;
            entity.DateRegistered = DateTime.Now;
            var newEntity = await _baseDataAcces.Add(entity);
            await _baseDataAcces.SaveAsync();
            return newEntity;
        }

        public async Task Delete(int id)
        {
            var existentCustomer = await _baseDataAcces.Get(id);
            if (existentCustomer == null)
                throw new BussinessException("Customer not found");

            existentCustomer.Active = false;
            _baseDataAcces.Update(existentCustomer);
            _baseDataAcces.Save();
        }
    }
}
