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
        private readonly AuthRepository _auth;

        public LocationController(LocRepository repo,
                                AuthRepository auth)
        {
            _repo = repo;
        }
        
        [HttpPost("AddLocation/{locName}")]
        public async Task<IActionResult> AddLocation(string locName)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.AddLocation == false)
            {
                return Unauthorized();
            }
            
            if (ModelState.IsValid)
            {
                var locToCreate = new Location
                {
                    Name = locName
                };
            

            var createdLocation = await _repo.AddLocation(locToCreate);

            //created at root status code
            return StatusCode(201);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLocation(int Id)//GetLocation(GetByIDDto getLocationDto)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewLocation == false)
            {
                return Unauthorized();
            }

            Location loc;
            loc = await _repo.GetLocation(Id); //GetLocation(getLocationDto.Id);

            return Ok(loc);
        }

        [HttpGet("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewLocation == false)
            {
                return Unauthorized();
            }

            var locList = await _repo.GetAllLocations();
            return Ok(locList);
        }

        [HttpGet()]
        public async Task<IActionResult> GetLocations(string Name, int LocInvID)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewLocation == false)
            {
                return Unauthorized();
            }

            var LocList = await _repo.GetLocations(Name, LocInvID);
            return Ok(LocList);
        }

        [HttpDelete("DeleteLocation")] //[HttpPost("DeleteLocation/{Id}")]
        public async Task<IActionResult> DeleteLocation(int Id)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.DeleteLocation == false)
            {
                return Unauthorized();
            }

            var deletedLocation = await _repo.DeleteLocation(Id);
            return StatusCode(201);
        }

    }
}