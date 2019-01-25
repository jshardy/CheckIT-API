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
                Email = customerCreateDto.Email,
            };

            var createdCustomer = _repo.CreateCustomer(customerToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpGet("GetCustomer")]
        public async Task<Customer> GetCustomer(int Id)
        {
            Customer customer;
            customer = await _repo.GetCustomer(Id);

            return customer;
        }

    }
}