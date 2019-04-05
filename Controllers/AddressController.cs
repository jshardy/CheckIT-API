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
using AutoMapper;

namespace CheckIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressRepository _repo;
        private readonly IMapper _mapper;

        public AddressController(AddressRepository repo,
                                 IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress(AddressData aData)
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
                    AptNum = aData.AptNum
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
        public async Task<IActionResult> ModifyAddress(int id, AddressData AddData)
        {
            var addressToPass = new Address
            {
                Country = AddData.Country,
                State = AddData.State,
                ZipCode = AddData.ZipCode,
                City = AddData.City,
                Street = AddData.Street,
                AptNum = AddData.AptNum
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

            var addressToReturn = new AddressData
            {
                Country = address.Country,
                State = address.State,
                ZipCode = address.ZipCode,
                City = address.City,
                Street = address.Street,
                AptNum = address.AptNum,
                AddressCustID = address.AddressCustID
            };

            //var addressToReturn = _mapper.Map<AddressData>(address);

            return Ok(addressToReturn);
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

            List<AddressData> addressListToReturn = new List<AddressData>();

            foreach (var item in AddressList)
            {
                var newAddress = new AddressData
                {
                    Country = item.Country,
                    State = item.State,
                    ZipCode = item.ZipCode,
                    City = item.City,
                    Street = item.Street,
                    AptNum = item.AptNum,
                    AddressCustID = item.AddressCustID
                };

                //addressListToReturn.Add(_mapper.Map<AddressData>(item));
            }

            return Ok(addressListToReturn);
        }
    }
}