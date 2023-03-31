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
    /// CustomerController
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        /// <summary>
        /// ICustomerService
        /// </summary>
        private readonly ICustomerService _customerService;

        /// <summary>
        /// IMapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// ILogger
        /// </summary>
        private readonly ILogger<CustomerController> _logger = null;

        /// <summary>
        /// CustomerController's constructor
        /// </summary>
        /// <param name="customerService"></param>
        /// <param name="mapper"></param>
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Returns all the customers 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(IEnumerable<CustomerDTO>)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Getting the customers");
            var types = await _customerService.GetAll();
            var typesDto = _mapper.Map<IEnumerable<CustomerDTO>>(types);
            return Ok(typesDto); //return status 200
        }

        

        /// <summary>
        /// Returns a specific customer by id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]/get/{id?}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(CustomerDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Getting the customer with id: {id}");
            var type = await _customerService.Get(id);
            if (type == null)
            {
                _logger.LogWarning("Customer not found");
                return NotFound();
            }

            var typeDto = _mapper.Map<CustomerDTO>(type);
            return Ok(typeDto); //return status 200
        }

        /// <summary>
        /// Create a new Customer
        /// </summary>
        /// <param name="customer">the data of the new customer </param>
        /// <returns>returns the data of the new customer</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = (typeof(CustomerDTO)))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add(AddCustomerRequest customer)
        {
            _logger.LogInformation("Adding a new customer");
            var customerToAdd = _mapper.Map<Customer>(customer);
            var newCustomer = await _customerService.Add(customerToAdd);
            var typeDto = _mapper.Map<CustomerDTO>(newCustomer);

            _logger.LogInformation($"Customer id:{typeDto.Id} added");
            return Ok(typeDto); //return status 200
        }


        /// <summary>
        /// Delete a customer with specified id
        /// </summary>
        /// <param name="customerId">the identifier of the customer to delete </param>
        /// <returns>returns http code</returns>
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int customerId)
        {
            _logger.LogInformation($"Deleting customer id: {customerId}");
            await _customerService.Delete(customerId);
            return Ok(); //return status 200
        }

    }
}
