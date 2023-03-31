using CarRentalCore.Interfaces;
using CarRentalCore.Requests;
using RentalCarCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class SecurityService : BaseService<User>, ISecurityService
    {
        private readonly IEncryptorService _encryptorService;
        public SecurityService (IBaseDataAcces<User> baseDataAcces,IEncryptorService encryptorService):base(baseDataAcces)
        {
            _encryptorService = encryptorService;
        }

        public async Task<User> GetLogin(UserLoginRequest login)
        {
            var users= await _baseDataAcces.GetAll();
            var user = users.FirstOrDefault(u => u.UserName == login.Email);

            return user;
        }

        public bool Check(string encryptedPAssword, string password)
        {

            return _encryptorService.Verify(encryptedPAssword, password);

        }

    }
}
