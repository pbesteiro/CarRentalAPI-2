using CarRentalCore.Requests;
using RentalCarCore.Entities;
using System.Threading.Tasks;

namespace CarRentalCore.Interfaces
{
    public interface ISecurityService
    {
        Task<User> GetLogin(UserLoginRequest login);
        bool Check(string encryptedPAssword, string password);
    }
}
