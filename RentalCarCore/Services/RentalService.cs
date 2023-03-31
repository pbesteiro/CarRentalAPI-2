using CarRentalCore.Interfaces;
using RentalCarCore.Entities;

namespace CarRentalCore.Services
{
    public class RentalService:BaseService<Rental>
    {       
        public RentalService(IBaseDataAcces<Rental> baseDataAcces):base(baseDataAcces)
        {
        }



    }
}
