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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repo;

        public AddressController(IAddressRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("CreateAddress")]
        public async Task<IActionResult> CreateAddress(AddressCreateDto addressCreateDto)
        {
            var addressToCreate = new Address
            {
                Country = addressCreateDto.Country,
                State = addressCreateDto.State,
                ZipCode = addressCreateDto.ZipCode,
                Street = addressCreateDto.Street,
                AptNum = addressCreateDto.AptNum,
                DefaultAddress = addressCreateDto.DefaultAddress
            };

            var CreatedAddress = await _repo.CreateAddress(addressToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpPost("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (await _repo.DeleteAddress(id))
                return StatusCode(201);
            return BadRequest("Could not find Address");
        }

        [HttpPost("DeleteAddresses")]
        public async Task<IActionResult> DeleteAddresses(ICollection<int> idCollection)
        {
            bool success = true;
            foreach (int id in idCollection)
                if (await _repo.DeleteAddress(id) == false)
                    success = false;
            if (success)
                return StatusCode(201);
            return BadRequest("One or more Addresses could not be found");
        }

        [HttpPost("ModifyAddress")]
        public async Task<IActionResult> ModifyAddress(int id, AddressCreateDto dataDto)
        {
            var addressToPass = new Address
            {
                Country = dataDto.Country,
                State = dataDto.State,
                ZipCode = dataDto.ZipCode,
                Street = dataDto.Street,
                AptNum = dataDto.AptNum,
                DefaultAddress = dataDto.DefaultAddress
            };

            if (await _repo.ModifyAddress(id, addressToPass))
                return StatusCode(201);

            return BadRequest("Could not find Address");
        }

        [HttpGet("GetAddress")]
        public async Task<Address> GetCustomer(int Id)
        {
            Address address;
            address = await _repo.GetAddress(Id);

            return address;
        }

        [HttpGet("GetAddresses")]
        public async Task<ICollection<Address>> GetAddresses(ICollection<int> idCollection)
        {
            ICollection<Address> collection = new Collection<Address>();
            foreach (int id in idCollection)
                collection.Add(await _repo.GetAddress(id));
            return collection;
        }


    }
}