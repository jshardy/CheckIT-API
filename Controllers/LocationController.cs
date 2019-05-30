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
        private readonly InventoryRepository _inv;

        public LocationController(LocRepository repo,
                                AuthRepository auth,
                                InventoryRepository inv)
        {
            _repo = repo;
            _auth = auth;
            _inv = inv;
        }

        [HttpPost("AddLocation")] // Removed Addlocation/{locString} so I can pass as a param
        public async Task<IActionResult> AddLocation(string locName, string locDesc)
        {
            // User user = await _auth.GetUser(this.User.Identity.Name);
            // Permissions permissions = await _auth.GetPermissions(user.Id);

            // if (permissions.AddLocation == false)
            // {
            //     return Unauthorized();
            // }

            // Josh - I removed user permissions in attempt to get this to work.

            if (ModelState.IsValid)
            {
                var locToCreate = new Location
                {
                    Name = locName,
                    Description = locDesc
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

        [HttpPatch("AddItemToLocation")]
        public async Task<IActionResult> AddItemToLocation(int LocId, int ItemId)//GetLocation(GetByIDDto getLocationDto)
        {
            /* 
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);

            if (permissions.AddLocation == false)
            {
                return Unauthorized();
            }
            */
            //
            Location loc;
            loc = await _repo.GetLocation(LocId); //GetLocation(getLocationDto.Id);

            Inventory item = _inv.GetInventory(ItemId).Result;

            if (loc == null)
            {
                return BadRequest("Location not found");
            }
            if (item == null)
            {
                return BadRequest("Item not found");
            }

            //
            //add location to item?
            //

            await _repo.AddItemToLocation(loc, item); //Location updatedLoc = await _repo.RemoveItemFromLocation(loc, item);

            return StatusCode(201); //return Ok(updatedLoc);
        }

        [HttpPatch("RemoveItemFromLocation")]
        public async Task<IActionResult> RemoveItemFromLocation(int LocId, int ItemId)
        {
            //update permissions

            Location loc;
            loc = await _repo.GetLocation(LocId); //GetLocation(getLocationDto.Id);

            Inventory item = _inv.GetInventory(ItemId).Result;

            if (loc == null)
            {
                return BadRequest("Location not found");
            }
            if (item == null)
            {
                return BadRequest("Item not found");
            }

            //
            //remove location from item?
            //

            await _repo.RemoveItemFromLocation(loc, item); //Location updatedLoc = await _repo.RemoveItemFromLocation(loc, item);

            return StatusCode(201); //return Ok(updatedLoc);
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

        [HttpPost("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(int id, string name, string desc) //LocationDto locData
        {
            /*User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.UpdateLocation == false)
            {
                return Unauthorized();
            }*/

            Location loc;
            loc = await _repo.GetLocation(id);

            if (loc == null)
            {
                return BadRequest("Location not found");
            }

            loc.Name = name;
            loc.Description = desc;

            var updatedLocation = await _repo.UpdateLocation(loc);

            //created at root status code
            return StatusCode(201);
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