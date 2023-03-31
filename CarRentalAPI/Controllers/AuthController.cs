using AutoMapper;
using CarRentalCore.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using CarRentalCore.Interfaces;
using CarRentalCore.Requests;
using RentalCarCore.Entities;

namespace CarRentalAPI.Controllers
{
    /// <summary>
    /// AuthController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// IUserService
        /// </summary>
        public readonly IUserService _userService;

        /// <summary>
        /// ISecurityService
        /// </summary>
        public readonly ISecurityService _securityService;

        /// <summary>
        /// IConfiguration
        /// </summary>
        public readonly IConfiguration _configuration;

        /// <summary>
        /// IMapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// AuthController
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="securityService"></param>
        /// <param name="mapper"></param>
        /// <param name="configuration"></param>
        public AuthController(IUserService userService, ISecurityService securityService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _securityService = securityService;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// Login the user to the system (TRY WITH: email: "admin@admin.com.edu" and pass:"1234" for login as admin)
        /// </summary>
        /// <param name="login">emial and password</param>
        /// <returns>JWT Access</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(UserLoginRequest)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Authentication(UserLoginRequest login)
        {
            //todo: add validation of valid user
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { Token = token });
            }

            return NotFound();

        }



       
        private async Task<IActionResult> CreateUser(AddUserRequest user)
        {

            var _user = _mapper.Map<User>(user);

            var newPost = await _userService.Add(_user);

            var userResponse = _mapper.Map<UserDTO>(newPost);

            return Ok(userResponse); //return status 200
        }

        private async Task<(bool, UserDTO)> IsValidUser(UserLoginRequest login)
        {
            var user = await _securityService.GetLogin(login);

            if (user == null)
                return (false, null);

            var userDTO = _mapper.Map<UserDTO>(user);


            var isValid = _securityService.Check(user.Password, login.Password + user.Salt);

            return (isValid, userDTO);
        }

        private string GenerateToken(UserDTO user)
        {
            //header
            var _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var _signingCredential = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(_signingCredential);


            //claims
            var claims = new[]{
                new Claim("userId",user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.UserName)
            };


            //payload
            var payload = new JwtPayload(
                _configuration["Authentication:Issuing"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1)
                );

            var token = new JwtSecurityToken(header, payload);

            //return serializated token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
