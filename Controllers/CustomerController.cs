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
                PhoneNumber = customerCreateDto.PhoneNumber,
                Email = customerCreateDto.Email
            };

            var createdCustomer = await _repo.CreateCustomer(customerToCreate, customerCreateDto.AddressID);

            //created at root status code
            return StatusCode(201);
        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _repo.DeleteCustomer(id))
                return StatusCode(201);
            return BadRequest("Could not find Customer");
        }

        [HttpPost("DeleteCustomers")]
        public async Task<IActionResult> DeleteCustomers(ICollection<int> idCollection)
        {
            bool success = true;
            foreach(int id in idCollection)
                if (await _repo.DeleteCustomer(id) == false)
                    success = false;
            if(success)
                return StatusCode(201);
            return BadRequest("One or more Customers could not be found");
        }

        [HttpPost("ModifyCustomer")]
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

        [HttpGet("GetCustomer")]
        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer;
            customer = await _repo.GetCustomer(id);

            return customer;
        }

        [HttpGet("GetCustomers")]
        public async Task<ICollection<Customer>> GetCustomers(ICollection<int> idCollection)
        {
            ICollection<Customer> collection = new Collection<Customer>();
            foreach(int id in idCollection)
                collection.Add(await _repo.GetCustomer(id));
            return collection;
        }

        [HttpGet("GetCustomersByFirstName")]
        public async Task<ICollection<Customer>> GetCustomersByFirstName(string firstName)
        {
            ICollection<Customer> collection = await GetCustomersByFirstName(firstName);
            return collection;
        }

        [HttpGet("GetCustomersByLastName")]
        public async Task<ICollection<Customer>> GetCustomersByLastName(string lastName)
        {
            ICollection<Customer> collection = await GetCustomersByLastName(lastName);
            return collection;
        }

        [HttpGet("GetCustomersByCompanyName")]
        public async Task<ICollection<Customer>> GetCustomersByCompanyName(string companyName)
        {
            ICollection<Customer> collection = await GetCustomersByCompanyName(companyName);
            return collection;
        }

        [HttpGet("GetCustomersByAddress")]
        public async Task<ICollection<Customer>> GetCustomersByAddress(Address address)
        {
            ICollection<Customer> collection = await GetCustomersByAddress(address);
            return collection;
        }

        [HttpGet("GetCustomersPhoneNumber")]
        public async Task<ICollection<Customer>> GetCustomersByPhoneNumber(string phone)
        {
            ICollection<Customer> collection = await GetCustomersByPhoneNumber(phone);
            return collection;
        }

        [HttpGet("GetCustomersByEmail")]
        public async Task<ICollection<Customer>> GetCustomersByEmail(string email)
        {
            ICollection<Customer> collection = await GetCustomersByEmail(email);
            return collection;
        }


    }
}