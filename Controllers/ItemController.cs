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

namespace CheckIT.API.Controllers
{
    //[Authorize] <-- you need to put this in any controller made
    //this [Authorize] attribute force the token to be used.
    //IE they don't have to relogin every time.
    //Do not enable it here, this is the "inventory" controller.
    //Use [AllowAnonymous] for controllers that don't need auth
    [Route("api/[controller]")]
    [ApiController] //this allows us to use [required] and other manditory constraints.
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repo;
        private readonly IConfiguration _config;

        public ItemController(IItemRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(ItemForAddDto itemForAddDto)
        {
            //validate request
            //itemForAddDto.Name = itemForAddDto.Name.ToLower();

            //check for duplicate name?
            //check for duplicate id?
            //if (await _repo.ItemExists(itemForAddDto.Name)) return BadRequest("Item already exists");

            var itemToCreate = new Item
            {
                UPC = itemForAddDto.UPC,
                Name = itemForAddDto.Name,
                Price = itemForAddDto.Price,
                Description = itemForAddDto.Description,
                Quantity = itemForAddDto.Quantity
            };

            var createdItem = _repo.AddItem(itemToCreate);

            //created at root status code
            return StatusCode(201);
        }

        [HttpGet("GetItem/{Id}")]
        public async Task<Item> GetItem(int Id)//GetItem(GetByIDDto getItemDto)
        {
            Item item;
            item = await _repo.GetItem(Id); //GetItem(getItemDto.Id);

            return item;
        }

        [HttpGet("GetAllItems")]
        public async Task<List<Item>> GetAllItems()
        {
            var itemList = await _repo.GetAllItems();
            return itemList;
        }

        [HttpPost("DeleteItem/{Id}")]
        public async Task<IActionResult> DeleteItem(int Id)
        {
            var deletedItem = await _repo.DeleteItem(Id);
            return StatusCode(201);
        }

        //[HttpPost("DeleteMultipleItems")]
        //public async Task<IActionResult> DeleteMultipleItems()

        [HttpPost("UpdateItem")]
        public async Task<IActionResult> UpdateItem(ItemForUpdateDto updateItemDto)
        {
            Item item;
            item = await _repo.GetItem(updateItemDto.Id);

            //probably a much better way to do this
            //possibly something like:
            //PropertyInfo[] properties = item.GetType().GetProperties();
            //foreach (PropertyInfo pi in properties)
            if (updateItemDto.Name != null) item.Name = updateItemDto.Name;
            if (updateItemDto.UPC != 0) item.UPC = updateItemDto.UPC;
            if (updateItemDto.Price != 0) item.Price = updateItemDto.Price;
            if (updateItemDto.Description != null) item.Description = updateItemDto.Description;
            if (updateItemDto.Quantity != 0) item.Quantity = updateItemDto.Quantity;

            var updatedItem = await _repo.UpdateItem(item);

            //created at root status code
            return StatusCode(201);
        }
    }
}