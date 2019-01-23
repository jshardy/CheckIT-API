using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

// add one/multiple (ICollection)
// remove one/multiple
// modify


namespace CheckIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustRepository _repo;

        public CustomerController(ICustRepository repo)
        {
             _repo = repo;
        }
        
        [AllowAnonymous]
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            var customerToCreate = new Customer
            {
                FirstName = customerCreateDto.FirstName,
                LastName = customerCreateDto.LastName,
                CompanyName = customerCreateDto.CompanyName,
                AddressID = customerCreateDto.AddressID,
                PhoneNumber = customerCreateDto.PhoneNumber,
                Email = customerCreateDto.Email
            };

            var createdCustomer = await _repo.CreateCustomer(customerToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(GetByIDDto deleteCustomerDto)
        {
            if (await _repo.DeleteCustomer(deleteCustomerDto.ID))
                return StatusCode(201);
            return BadRequest("Could not find Customer");
        }

        [HttpPost("ModifyCustomer")]
        public async Task<IActionResult> ModifyCustomer(GetByIDDto iDDto, CustomerCreateDto dataDto)
        {
            var custToPass = new Customer
            {
                FirstName = dataDto.FirstName,
                LastName = dataDto.LastName,
                CompanyName = dataDto.CompanyName,
                AddressID = dataDto.AddressID,
                PhoneNumber = dataDto.PhoneNumber,
                Email = dataDto.Email
            };

            if (await _repo.ModifyCustomer(iDDto.ID, custToPass))
                return StatusCode(201);

            return BadRequest("Could not find Customer");
        }

        [HttpGet("GetCustomer")]
        public async Task<Customer> GetCustomer(GetByIDDto getCustomerDto)
        {
            Customer customer;
            customer = await _repo.GetCustomer(getCustomerDto.ID);
            
            return customer;
        }

    }
}