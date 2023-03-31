using RentalCarCore.Entities;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(int id);
        Task<User> Add(User user);
    }
}
