using System;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public  interface IPriceService
    {
        Task<double> GetPrice(DateTime from, int modelId);
    }
}
