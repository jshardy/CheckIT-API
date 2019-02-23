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
using CheckIT.API.Models.BindingTargets;
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
    public class AddressController : ControllerBase
    {
        private readonly AddressRepository _repo;

        public AddressController(AddressRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress([FromBody] AddressData aData)
        {
            if (ModelState.IsValid)
            {
                var addressToCreate = new Address
                {
                    Country = aData.Country,
                    State = aData.State,
                    ZipCode = aData.ZipCode,
                    City = aData.City,
                    Street = aData.Street,
                    AptNum = aData.AptNum,
                    DefaultAddress = aData.DefaultAddress
                };
            
                var CreatedAddress = await _repo.CreateAddress(addressToCreate);
                
                return Ok(CreatedAddress);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (await _repo.DeleteAddress(id))
                return StatusCode(201);
            return BadRequest("Could not find Address");
        }

        // [HttpPost("DeleteAddresses")]
        // public async Task<IActionResult> DeleteAddresses(ICollection<int> idCollection)
        // {
        //     bool success = true;

        //     foreach (int id in idCollection)
        //         if (await _repo.DeleteAddress(id) == false)
        //             success = false;
        //     if (success)
        //         return StatusCode(201);

        //     return BadRequest("One or more Addresses could not be found");
        // }

        [HttpPatch("ModifyAddress")]
        public async Task<IActionResult> ModifyAddress(int id, AddressCreateDto dataDto)
        {
            var addressToPass = new Address
            {
                Country = dataDto.Country,
                State = dataDto.State,
                ZipCode = dataDto.ZipCode,
                City = dataDto.City,
                Street = dataDto.Street,
                AptNum = dataDto.AptNum,
                DefaultAddress = dataDto.DefaultAddress
            };

            if (await _repo.ModifyAddress(id, addressToPass))
                return StatusCode(201);

            return BadRequest("Could not find Address");
        }

        // What does this intend to do?
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int Id)
        {
            Address address;
            address = await _repo.GetAddress(Id);

            return Ok(address);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAddresses(string country = "", 
                                                            string state = "",
                                                            string zip = "",
                                                            string city = "",
                                                            string street = "",
                                                            int CustomerAddID = -1)
        {
            var AddressList = await _repo.GetAddresses(country, 
                                                    state,
                                                    zip,
                                                    city,
                                                    street,
                                                    CustomerAddID);
            return Ok(AddressList);
        }
    }
}