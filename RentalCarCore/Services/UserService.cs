using CarRentalCore.Exceptions;
using CarRentalCore.Interfaces;
using RentalCarCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalCore.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IEncryptorService _encryptorService;

        public UserService(IBaseDataAcces<User> baseDataAcces, IEncryptorService encriptorServices):base(baseDataAcces)
        {
            _encryptorService = encriptorServices;
        }
                

        public override async Task<User> Add(User _user)
        {
            //validate the model
            ValidateModel(_user);

            //validate that not exist another user with the same email
            var users = await _baseDataAcces.GetAll();
            var usersWithSameEmail = users.Where(u => u.UserName == _user.UserName);
            if (usersWithSameEmail.Count() > 0)
            {
                throw new BussinessException($"An user whith email {_user.UserName} already exists!");
            }

            
            //ecript the password
            var salt = _encryptorService.CreateSalt();
            var encryptedPass = _encryptorService.Encrypt(_user.Password + salt);
            _user.Password = encryptedPass;
            _user.Salt = salt;

            //add the user
            await _baseDataAcces.Add(_user);
            await _baseDataAcces.SaveAsync();

            return _user;
        }


        private void ValidateModel(User _user)
        {

            //validate user email           
            if (string.IsNullOrWhiteSpace(_user.UserName))
                throw new BussinessException("The username must have a lenght greathen than 0");

            if (!_user.UserName.Contains("@"))
                throw new BussinessException("The email must contains @");
                        
            

        }

    }
}
