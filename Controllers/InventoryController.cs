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

namespace CheckIT.API.Controllers
{
    //[Authorize] <-- you need to put this in any controller made
    //this [Authorize] attribute force the token to be used.
    //IE they don't have to relogin every time.
    //Do not enable it here, this is the "auth" controller.
    //Use [AllowAnonymous] for controllers that don't need auth
    [Route("api/[controller]")]
    [ApiController] //this allows us to use [required] and other manditory constraints.
    public class InventoryController : ControllerBase
    {
        //private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IItemRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("AddItem")]
        // [FromBody] this is infered for ItemForAddDto by [ApiController]
        public async Task<IActionResult> AddItem(ItemForAddDto itemForAddDto)
        {
            //Must use this if don't use [ApiController]
            //if(!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //validate request
            //itemForAddDto.Name = itemForAddDto.Name.ToLower();

            //check for duplicate name?
            //check for duplicate id?
            //if (await _repo.ItemExists(itemForAddDto.Name)) return BadRequest("Item already exists");

            //generate the ID

            var itemToCreate = new Item
            {
                Id = itemForAddDto.Id,
                UPC = itemForAddDto.UPC,
                Name = itemForAddDto.Name,
                Price = itemForAddDto.Price,
                Description = itemForAddDto.Description
            };

            var createdItem = await _repo.AddItem(itemToCreate);

            //created at root status code
            return StatusCode(201);
        }

    }
}