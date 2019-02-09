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
    public class InventoryController : ControllerBase
    {
        private readonly InventoryRepository _repo;

        public InventoryController(InventoryRepository repo)
        {
            _repo = repo;
        }
        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("AddInventory")]
        public async Task<IActionResult> AddInventory(InventoryForAddDto itemForAddDto)
        {
            //validate request
            //itemForAddDto.Name = itemForAddDto.Name.ToLower();

            //check for duplicate name?
            //if (await _repo.InventoryExists(itemForAddDto.Name)) return BadRequest("Inventory already exists");

            var itemToCreate = new Inventory
            {
                UPC = itemForAddDto.UPC,
                Name = itemForAddDto.Name,
                Price = itemForAddDto.Price,
                Description = itemForAddDto.Description,
                Quantity = itemForAddDto.Quantity,
                AlertBit = itemForAddDto.AlertBit
            };

            var createdInventory = await _repo.AddInventory(itemToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpGet("GetInventory/{Id}")]
        public async Task<IActionResult> GetInventory(int Id)//GetInventory(GetByIDDto getInventoryDto)
        {
            Inventory inventory;
            inventory = await _repo.GetInventory(Id); //GetInventory(getInventoryDto.Id);

            return Ok(inventory);
        }

        [HttpGet("GetAllInventories")]
        public async Task<IActionResult> GetAllInventories()
        {
            var itemList = await _repo.GetAllInventories();
            return Ok(itemList);
        }

        [HttpDelete("{Id}")] //[HttpDelete("DeleteInventory/{Id}")]
        public async Task<IActionResult> DeleteInventory(int Id)
        {
            var deletedInventory = await _repo.DeleteInventory(Id);
            return StatusCode(201);
        }

        [HttpPost("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory(InventoryForUpdateDto updateInventoryDto)
        {
            Inventory inventory;
            inventory = await _repo.GetInventory(updateInventoryDto.Id);

            //probably a much better way to do this
            //possibly something like:
            //PropertyInfo[] properties = inventory.GetType().GetProperties();
            //foreach (PropertyInfo pi in properties)
            inventory.Name = updateInventoryDto.Name;
            inventory.UPC = updateInventoryDto.UPC;
            inventory.Price = updateInventoryDto.Price;
            inventory.Description = updateInventoryDto.Description;
            inventory.Quantity = updateInventoryDto.Quantity;
            inventory.AlertBit = updateInventoryDto.AlertBit;

            var updatedInventory = await _repo.UpdateInventory(inventory);

            //created at root status code
            return StatusCode(201);
        }

        [HttpPatch("CheckAlertBit/{Id}")]
        public async Task<IActionResult> CheckAlertBit(int Id)
        {
            Inventory inventory;
            inventory = await _repo.GetInventory(Id);

            if (inventory.AlertBit == false)
            {
                inventory.AlertBit = true;
                var updatedInventory = await _repo.UpdateInventory(inventory);
            }

            //created at root status code
            return StatusCode(201);
        }

        [HttpPatch("UncheckAlertBit/{Id}")]
        public async Task<IActionResult> UncheckAlertBit(int Id)
        {
            Inventory inventory;
            inventory = await _repo.GetInventory(Id);

            if (inventory.AlertBit == true)
            {
                inventory.AlertBit = false;
                var updatedInventory = await _repo.UpdateInventory(inventory);
            }

            //created at root status code
            return StatusCode(201);
        }
    }
}