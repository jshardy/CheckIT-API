using System;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using CheckIT.API.Helpers;
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
        private readonly IMapper _mapper;

        public CustomerController(CustRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerData cData)
        {
            if (ModelState.IsValid)
            {
                var customerToCreate = new Customer
                {
                    FirstName = cData.FirstName,
                    LastName = cData.LastName,
                    CompanyName = cData.CompanyName,
                    PhoneNumber = cData.PhoneNumber,
                    Email = cData.Email
                };

                // var addressToCreate = new Address
                // {
                //     Country = cData.CustAddress.Country,
                //     State = cData.CustAddress.State,
                //     ZipCode = cData.CustAddress.ZipCode,
                //     City = cData.CustAddress.City,
                //     Street = cData.CustAddress.Street,
                //     AptNum = cData.CustAddress.AptNum,
                //     DefaultAddress = cData.CustAddress.DefaultAddress,
                //     AddressCustID = customerToCreate.Id,
                //     AddressCust = customerToCreate
                // };

                customerToCreate.CustAddress = null;

                var createdCustomer = await _repo.CreateCustomer(customerToCreate);

                //created at root status code
                return StatusCode(201);
            }
            else
            {
                return BadRequest(ModelState);

            }
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _repo.DeleteCustomer(id))
                return StatusCode(201);
            return BadRequest("Could not find Customer");
        }

        // I don't think we need this functionality
        // Yeah, screw that! If a mothersucker posts something, it should follow him for the rest of his life!
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
        public async Task<IActionResult> ModifyCustomer(int id, CustomerData CustData)
        {
            var custToPass = new Customer
            {
                FirstName = CustData.FirstName,
                LastName = CustData.LastName,
                CompanyName = CustData.CompanyName,
                PhoneNumber = CustData.PhoneNumber,
                Email = CustData.Email
            };

            if (await _repo.ModifyCustomer(id, custToPass, CustData.AddressID))
                return StatusCode(201);

            return BadRequest("Could not find Customer");
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer;
            customer = await _repo.GetCustomer(id);

            var customerToReturn = _mapper.Map<CustomerData>(customer);

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