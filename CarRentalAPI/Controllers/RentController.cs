using AutoMapper;
using CarRentalCore.DTOs;
using CarRentalCore.Interfaces;
using CarRentalCore.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CarRentalAPI.Controllers
{
    /// <summary>
    /// RentController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RentController : Controller
    {
        /// <summary>
        /// IRentService
        /// </summary>
        public readonly IRentService _rentService;
        /// <summary>
        /// IMapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<RentController> _logger = null;

        /// <summary>
        /// RentController's constructor
        /// </summary>
        /// <param name="rentService"></param>
        /// <param name="mapper"></param>
        public RentController(IRentService rentService, ILogger<RentController> logger, IMapper mapper)
        {
            _rentService = rentService;
            _mapper = mapper;
            _logger=logger;
        }

        /// <summary>
        /// Returns all the rents 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(IEnumerable<RentalDTO>)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var types = await _rentService.GetAll();
            var typesDto = _mapper.Map<IEnumerable<RentalDTO>>(types);
            return Ok(typesDto); //return status 200
        }



        /// <summary>
        /// Returns a specific rent by id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/get/{id?}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(RentalDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Getting the rent with id: {id}");
            var type = await _rentService.Get(id);
            if (type == null)
            {
                _logger.LogInformation($"Rent with id: {id} not found");
                return NotFound("Rent not found");
            }

            var typeDto = _mapper.Map<RentalDTO>(type);
            return Ok(typeDto); //return status 200
        }

        /// <summary>
        /// Create a new Rent
        /// </summary>
        /// <param name="request">the data of the new rent </param>
        /// <returns>returns the data of the new rent</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(RentalDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add(AddRentRequest request)
        {
            var rentToAdd= _mapper.Map<Rental>(request);
            var newRent = await _rentService.Add(rentToAdd);
            var typeDto = _mapper.Map<RentalDTO>(newRent);

            return Ok(typeDto); //return status 200
        }


        /// <summary>
        /// Delete a rent with specified id
        /// </summary>
        /// <param name="rentId">the identifier of the rent to delete </param>
        /// <returns>returns http code</returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Deleting the rent with id: {id}");            
            await _rentService.Delete(id);

            return Ok(); //return status 200
        }
    }
}
