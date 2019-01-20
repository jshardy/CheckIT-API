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
        
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            if (!(Regex.Match(customerCreateDto.PhoneNumber, @"(((0-9)(0-9)(0-9)-)?(0-9)(0-9)(0-9)-(0-9)(0-9)(0-9)(0-9)").Success))
                return BadRequest("Invalid phone number");

            if (!(Regex.Match(customerCreateDto.Email, @".@.\..").Success))
                return BadRequest("Invlaid email");

            var customerToCreate = new Customer
            {
                FirstName = customerCreateDto.FirstName,
                LastName = customerCreateDto.LastName,
                CompanyName = customerCreateDto.CompanyName,
                AddressID = customerCreateDto.AddressID,
                PhoneNumber = customerCreateDto.PhoneNumber,
                Email = customerCreateDto.Email,
            };

            var createdCustomer = await _repo.CreateCustomer(customerToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpPost("GetCustomer")]
        public async Task<IActionResult> GetCustomer(GetByIDDto getCustomerDto)
        {
            Customer customer;
            customer = await _repo.GetCustomer(getCustomerDto.ID);
            
            return StatusCode(201);
        }

    }
}