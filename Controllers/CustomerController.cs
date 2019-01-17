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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] //this allows us to use [required] and other manditory constraints.
    public class CustomerController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public CustomerController()
        {
            // _repo = repo;
        }
        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("CreateCustomer")]
        // [FromBody] this is infered for UserForRegisterDto by [ApiController]
        public async Task<IActionResult> CreateCustomer(CustomerCreateDto customerCreateDto)
        {
            // if (!(Regex.Match(CustomerCreateDto.PhoneNumber, @"(([0-9][0-9][0-9]-)?[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]").Success))
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

    }
}