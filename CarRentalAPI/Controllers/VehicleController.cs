using AutoMapper;
using CarRentalCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CarRentalCore.DTOs;
using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CarRentalCore.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CarRentalAPI.Controllers
{
    /// <summary>
    /// VehicleController
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]    
    public class VehicleController: Controller
    {
        /// <summary>
        /// IVehicleService
        /// </summary>
        public readonly IVehicleService _vehicleService;

        /// <summary>
        /// IMapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<VehicleController> _logger = null;

        /// <summary>
        /// VehicleController's constructor
        /// </summary>
        /// <param name="vehicleService"></param>
        /// <param name="mapper"></param>
        public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Returns all the Vehicle Type 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(IEnumerable<VehicleDTO>)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            var types = await _vehicleService.GetAll();
            var typesDto = _mapper.Map<IEnumerable<VehicleDTO>>(types);
            return Ok(typesDto); //return status 200
        }

        /// <summary>
        /// Returns all the availables vehicles 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/availables")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(IEnumerable<VehicleDTO>)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Availables([FromQuery] AvailableVehiclesRequest request)
        {
            var types = await _vehicleService.GetAvailables(request);
            var typesDto = _mapper.Map<IEnumerable<VehicleDTO>>(types);
            return Ok(typesDto); //return status 200
        }

        /// <summary>
        /// Returns a specific Vehicle Type by id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/get/{id?}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(VehicleDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Getting vehicle id {id}");
            var type = await _vehicleService.Get(id);
            if (type == null)
            {
                _logger.LogWarning($"Vehicle id {id} not found");
                return NotFound();
            }

            var typeDto = _mapper.Map<VehicleDTO>(type);
            return Ok(typeDto); //return status 200
        }

        /// <summary>
        /// Create a new Vehicle Type
        /// </summary>
        /// <param name="vehicle">the data of the new vehicle </param>
        /// <returns>return the data of the new  Vehicle Type and his new id</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(VehicleDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add(AddVechicleRequest vehicle)
        {
            _logger.LogInformation("Adding new vehicle");
            var vehicleToAdd = new Vehicle { Domain=vehicle.Domain, ModelID=vehicle.ModelID };
            var newVehicle = await _vehicleService.Add(vehicleToAdd);
            var typeDto = _mapper.Map<VehicleDTO>(newVehicle);

            _logger.LogInformation($"Vehicle id: {typeDto.Id} added");
            return Ok(typeDto); //return status 200
        }

        /// <summary>
        /// Delete a vehicle with specified id
        /// </summary>
        /// <param name="vehicleId">the identifier of the vehicle to delete </param>
        /// <returns>return the data of the new vehicle and his new id</returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int vehicleId)
        {            
            await _vehicleService.Delete(vehicleId);
            return Ok(); //return status 200
        }

    }
}
