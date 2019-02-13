using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace CheckIT.API.Controllers
{
    //[Authorize] <-- you need to put this in any controller made
    //this [Authorize] attribute force the token to be used.
    //IE they don't have to relogin every time.
    //Do not enable it here, this is the "inventory" controller.
    //Use [AllowAnonymous] for controllers that don't need auth
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] //this allows us to use [required] and other manditory constraints.
    public class LocationController : ControllerBase
    {
        private readonly LocRepository _repo;

        public LocationController(LocRepository repo)
        {
            _repo = repo;
        }
        
        [HttpPost("AddLocation/{locName}")]
        public async Task<IActionResult> AddLocation(string locName)
        {
            //check for duplicate name?
            //if (await _repo.LocationExists(locForAddDto.Name)) return BadRequest("Location already exists");

            var locToCreate = new Location
            {
                Name = locName
            };

            var createdLocation = await _repo.AddLocation(locToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLocation(int Id)//GetLocation(GetByIDDto getLocationDto)
        {
            Location loc;
            loc = await _repo.GetLocation(Id); //GetLocation(getLocationDto.Id);

            return Ok(loc);
        }

        [HttpGet("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var locList = await _repo.GetAllLocations();
            return Ok(locList);
        }

        [HttpGet()]
        public async Task<IActionResult> GetLocations(string Name, int LocInvID)
        {
            var LocList = await _repo.GetLocations(Name, LocInvID);
            return Ok(LocList);
        }

        [HttpDelete("DeleteLocation")] //[HttpPost("DeleteLocation/{Id}")]
        public async Task<IActionResult> DeleteLocation(int Id)
        {
            var deletedLocation = await _repo.DeleteLocation(Id);
            return StatusCode(201);
        }

    }
}