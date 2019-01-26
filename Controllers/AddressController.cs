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
        public async Task<IActionResult> DeleteAddress(GetByIDDto DeleteAddressDto)
        {
            if (await _repo.DeleteAddress(DeleteAddressDto.ID))
                return StatusCode(201);
            return BadRequest("Could not find Address");
        }

        [HttpPost("ModifyAddress")]
        public async Task<IActionResult> ModifyAddress(GetByIDDto iDDto, AddressCreateDto dataDto)
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

            if (await _repo.ModifyAddress(iDDto.ID, addressToPass))
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

    }
}