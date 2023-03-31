using CarRentalCore.Interfaces;
using RentalCarCore.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class PriceService : BaseService<RentalPrice>, IPriceService
    {
        public PriceService(IBaseDataAcces<RentalPrice> baseDataAcces) : base(baseDataAcces)
        {
        }

        public async Task<double> GetPrice(DateTime from, int modelId)
        {
            var prices = await _baseDataAcces.GetAll();
            var price = prices.FirstOrDefault(p =>  from >= p.DateFrom &&  from <= p.DateTo && p.ModelID==modelId);
            if (price == null)
                return 0;
            return price.PricePerDay;
        }

    }
}
