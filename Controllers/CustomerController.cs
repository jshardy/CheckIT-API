using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustRepository _repo;

        public CustomerController(CustRepository repo)
        {
             _repo = repo;
        }

        [AllowAnonymous]
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerCreateDto customerCreateDto)
        {
            var customerToCreate = new Customer
            {
                FirstName = customerCreateDto.FirstName,
                LastName = customerCreateDto.LastName,
                CompanyName = customerCreateDto.CompanyName,
                PhoneNumber = customerCreateDto.PhoneNumber,
                Email = customerCreateDto.Email
            };

            var createdCustomer = await _repo.CreateCustomer(customerToCreate, customerCreateDto.AddressID);

            //created at root status code
            return StatusCode(201);
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _repo.DeleteCustomer(id))
                return StatusCode(201);
            return BadRequest("Could not find Customer");
        }

        // I don't think we need this functionality
        // [HttpPost("DeleteCustomers")]
        // public async Task<IActionResult> DeleteCustomers(ICollection<int> idCollection)
        // {
        //     bool success = true;
        //     foreach(int id in idCollection)
        //         if (await _repo.DeleteCustomer(id) == false)
        //             success = false;
        //     if(success)
        //         return StatusCode(201);
        //     return BadRequest("One or more Customers could not be found");
        // }

        [HttpPatch("ModifyCustomer")]
        public async Task<IActionResult> ModifyCustomer(int id, CustomerCreateDto dataDto)
        {
            var custToPass = new Customer
            {
                FirstName = dataDto.FirstName,
                LastName = dataDto.LastName,
                CompanyName = dataDto.CompanyName,
                PhoneNumber = dataDto.PhoneNumber,
                Email = dataDto.Email
            };

            if (await _repo.ModifyCustomer(id, custToPass, dataDto.AddressID))
                return StatusCode(201);

            return BadRequest("Could not find Customer");
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer;
            customer = await _repo.GetCustomer(id);

            return customer;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCustomers(string FirstName = "", 
                                                            string LastName = "", 
                                                            string CompanyName = "", 
                                                            bool IsCompany = false,
                                                            string PhoneNumber = "",
                                                            string Email = "")
        {
            var customerList = await _repo.GetCustomers(FirstName, 
                                                        LastName, 
                                                        CompanyName, 
                                                        IsCompany,
                                                        PhoneNumber,
                                                        Email);

            return Ok(customerList);
        }
    }
}