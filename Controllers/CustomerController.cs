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
        private readonly AddressRepository _Arepo;
        private readonly IMapper _mapper;
        private readonly AuthRepository _auth;

        public CustomerController(CustRepository repo, 
                                AddressRepository Arepo, 
                                IMapper mapper,
                                AuthRepository auth)
        {
            _mapper = mapper;
            _Arepo = Arepo;
            _repo = repo;
            _auth = auth;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerData cData)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.AddCustomer == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                //var customerToCreate = _mapper.Map<Customer>(cData);
                //customerToCreate.CustAddress = _mapper.Map<Address>(cData.CustAddress);

                var customerToCreate = new Customer
                {
                    FirstName = cData.FirstName,
                    LastName = cData.LastName,
                    CompanyName = cData.CompanyName,
                    IsCompany = cData.IsCompany,
                    PhoneNumber = cData.PhoneNumber,
                    Email = cData.Email,
                    QB_Id = -1
                };

                if (cData.CustAddress == null)
                    customerToCreate.CustAddress = new Address { };
                else
                    customerToCreate.CustAddress = new Address
                    {
                        Country = cData.CustAddress.Country,
                        State = cData.CustAddress.State,
                        ZipCode = cData.CustAddress.ZipCode,
                        City = cData.CustAddress.City,
                        Street = cData.CustAddress.Street,
                        AptNum = cData.CustAddress.AptNum,
                        AddressCustID = cData.CustAddress.AddressCustID
                    };

                var createdCustomer = await _repo.CreateCustomer(customerToCreate);

                //created at root status code
                //return StatusCode(201);
                return Ok(createdCustomer);
            }
            else
            {
                return BadRequest(ModelState);

            }
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.DeleteCustomer == false)
            {
                return Unauthorized();
            }

            if (await _repo.DeleteCustomer(id))
                return StatusCode(201);
            return BadRequest("Could not find Customer");
        }

        [HttpPatch("ModifyCustomer")]
        public async Task<IActionResult> ModifyCustomer(int id, CustomerData CustData)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.UpdateCustomer == false)
            {
                return Unauthorized();
            }

            var custToPass = new Customer
            {
                FirstName = CustData.FirstName,
                LastName = CustData.LastName,
                CompanyName = CustData.CompanyName,
                PhoneNumber = CustData.PhoneNumber,
                Email = CustData.Email
            };

            if (await _repo.ModifyCustomer(id, custToPass, CustData.CustAddressId))
                return StatusCode(201);

            return BadRequest("Could not find Customer");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id) //public async Task<CustomerData> GetCustomer(int id)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);

            if (permissions.ViewCustomer == false)
            {
                return Unauthorized();
            }

            Customer customer;
            customer = await _repo.GetCustomer(id);

            var customerToReturn = _mapper.Map<CustomerData>(customer);
            customerToReturn.CustomerInvoiceList = customer.CustomerInvoiceList.toIntList();
            

            return Ok(customerToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> GetCustomers(string FirstName = "",
                                                        string LastName = "",
                                                        string CompanyName = "",
                                                        bool IsCompany = false,
                                                        string PhoneNumber = "",
                                                        string Email = "")
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);

            if (permissions.ViewCustomer == false)
            {
                return Unauthorized();
            }

            var customerList = await _repo.GetCustomers(FirstName,
                                                        LastName,
                                                        CompanyName,
                                                        IsCompany,
                                                        PhoneNumber,
                                                        Email);

            List<CustomerData> customerListToReturn = new List<CustomerData>();

            foreach (var item in customerList)
            {
                customerListToReturn.Add(_mapper.Map<CustomerData>(item));
            }

            for (int i = 0; i < customerListToReturn.Count; i++)
            {
                customerListToReturn[i].CustomerInvoiceList = customerList[i].CustomerInvoiceList.toIntList();
            }

            return Ok(customerListToReturn);
        }
    }
}