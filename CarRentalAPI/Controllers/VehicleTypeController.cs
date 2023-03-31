using AutoMapper;
using CarRentalCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CarRentalCore.DTOs;
using RentalCarCore.Entities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CarRentalAPI.Controllers
{
    /// <summary>
    /// VehicleTypeController
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class VehicleTypeController : Controller
    {
        /// <summary>
        /// IVehicleTypeService
        /// </summary>
        public readonly IVehicleTypeService _vehicleTypeService;

        /// <summary>
        /// IMapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// VehicleTypeController
        /// </summary>
        /// <param name="vehicleTypeService"></param>
        /// <param name="mapper"></param>
        public VehicleTypeController(IVehicleTypeService vehicleTypeService, IMapper mapper)
        {
            _vehicleTypeService = vehicleTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all the Vehicle Type 
        /// </summary>
        /// <returns></returns>
        [HttpGet]       
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(IEnumerable<VehicleTypeDTO>)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var types = await  _vehicleTypeService.GetAll();
            var typesDto = _mapper.Map<IEnumerable<VehicleTypeDTO>>(types);
            return Ok(typesDto); //return status 200
        }

        /// <summary>
        /// Returns a specific Vehicle Type by id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(VehicleTypeDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var type= await _vehicleTypeService.Get(id);
            if (type == null)
                return NotFound();

            var typeDto = _mapper.Map<VehicleTypeDTO>(type);
            return Ok(typeDto); //return status 200
        }

        /// <summary>
        /// Create a new Vehicle Type
        /// </summary>
        /// <param name="type">the data of the new  Vehicle Type</param>
        /// <returns>return the data of the new  Vehicle Type and his new id</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(VehicleTypeDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add(VehicleTypeDTO type)
        {

            var typeToAdd = _mapper.Map<VehicleType>(type);
            var newType = _vehicleTypeService.Add(typeToAdd);
            var typeDto = _mapper.Map<VehicleTypeDTO>(newType);

            return Ok(typeDto); //return status 200
        }


    }
}
