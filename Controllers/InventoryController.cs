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

//For WebAPI
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using CheckIT.API.JSObjects;

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
        public async Task<IActionResult> AddInventory(InventoryData iData)
        {
           if(ModelState.IsValid)
           {
                var itemToCreate = new Inventory
                {
                    UPC = iData.UPC,
                    Name = iData.Name,
                    Price = iData.Price,
                    Description = iData.Description,
                    Quantity = iData.Quantity,
                    InventoryLocationID = iData.InventoryLocationID,
                    InventoryAlertID = iData.InventoryAlertID
                };

                var createdInventory = await _repo.AddInventory(itemToCreate);

                //created at root status code
                return StatusCode(201);
           }
           else
           {
               return BadRequest(ModelState);
           }
        }

        [HttpGet("{Id}")]
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

        [HttpDelete("DeleteInventory")] //[HttpDelete("DeleteInventory/{Id}")]
        public async Task<IActionResult> DeleteInventory(int Id)
        {
            var archivedInventory = await _repo.ArchiveInventory(Id);
            return StatusCode(201);
        }

        [HttpPost("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory(InventoryData InvenData)
        {
            Inventory inventory;
            inventory = await _repo.GetInventory(InvenData.Id);

            //probably a much better way to do this
            //possibly something like:
            //PropertyInfo[] properties = inventory.GetType().GetProperties();
            //foreach (PropertyInfo pi in properties)
            inventory.Name = InvenData.Name;
            inventory.UPC = InvenData.UPC;
            inventory.Price = InvenData.Price;
            inventory.Description = InvenData.Description;
            inventory.Quantity = InvenData.Quantity;
            //inventory.AlertBit = InvenData.AlertBit;

            var updatedInventory = await _repo.UpdateInventory(inventory);

            //created at root status code
            return StatusCode(201);
        }

        [HttpGet()]
        public async Task<IActionResult> GetInventories(string UPC = "",
                                                    string Name = "",
                                                    decimal Price = -1,
                                                    int Quantity = -1,
                                                    bool Archived = false,
                                                    int LocationId = -1,
                                                    int AlertId = -1)
        {
            var inventoryList = await _repo.GetInventories(UPC,
                                                      Name,
                                                      Price,
                                                      Quantity,
                                                      Archived,
                                                      LocationId,
                                                      AlertId);
            return Ok(inventoryList);
        }

        [HttpGet("GetItemByUPC")]

        public async Task<IActionResult> GetItemByUPC(string UPC)
        {
            Inventory inventory = await _repo.GetItemByUPC(UPC);
            JSItem item = new JSItem();

            if (inventory != null)
            {
                item.Id = inventory.Id;
                item.Name = inventory.Name;
                item.Description = inventory.Description;
                item.Price = inventory.Price;
                item.Quantity = inventory.Quantity;
                item.UPC = inventory.UPC;
                item.LocationId = inventory.InventoryLocationID;
                item.AlertId = inventory.InventoryAlertID;
            }
            return Ok(item);
        }
        public class UpcDatabaseResponse
        {
            public string UpcNumber { get; set; } //public long UpcNumber { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public string Size { get; set; }
            public string Brand { get; set; }
            public decimal Msrp { get; set; }
        }

        //https://jonhilton.net/2017/01/24/retrieve-data-from-a-third-party-openweather-api-using-asp-net-core-web-api/
        //example call: http://localhost:5000/api/Inventory/UpcInfo/028400003001
        //example response: {"upcnumber":"028400003001","st0s":"","newupc":"","type":"","title":"Lay's\u00ae Barbecue Flavored Potato Chips 1.5 oz. Bag",
        //"alias":"","description":"&lt;ul&gt;&lt;li&gt;1.5 oz. bag of LAY'S Barbecue Flavored Potato Chips&lt;\/li&gt;&lt;li&gt;Loved LAY'S flavor
        //to enjoy as an any time snack&lt;\/li&gt;&lt;li&gt;Delicious snack for pairing with a small meal&lt;\/li&gt;&lt;li&gt;
        //Delicious LAY'S crunchy snack&lt;\/li&gt;&lt;\/ul&gt;","brand":"Lay's","category":"Food\/Snacks, Cookies & Chips\/Chips","size":"1.5 oz",
        //"color":"Other","gender":"","age":"","unit":"","msrp":"70.48","rate\/up":"0","rate\/down":"0","status":200,"error":false}
        [AllowAnonymous] //remove -- just for testing
        [HttpGet("UpcInfo/{upc}")]
        public async Task<IActionResult> UpcInfo(string upc)
        {
            string api_key = "885E280DD8093B3A325FC573847937CB";
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.upcdatabase.org");
                    //example:      var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid=YOUR_API_KEY_HERE&units=metric");
                    var response = await client.GetAsync($"/product/{upc}/{api_key}");
                    response.EnsureSuccessStatusCode();

                    //return Ok(response); //returns raw request response

                    var stringResult = await response.Content.ReadAsStringAsync();
                    //return Ok(stringResult); //returns entire database response, all json info
                    var rawProduct = JsonConvert.DeserializeObject<UpcDatabaseResponse>(stringResult);
                    return Ok(rawProduct); //returns just neccessariy info
                    /*return Ok(new {
                        Upc = rawProduct.Upc,
                        Name = rawProduct.Name,
                        Description = rawProduct.Description,
                        Brand = rawProduct.Brand
                    });*/
                    //example:  Description = string.Join(",", rawWeather.Weather.Select(x=>x.Main)),
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting data from UPCDatabase: {httpRequestException.Message}");
                }
            }
        }

        //The following are all methods for modifying the alertbit
        /*
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

        [HttpPatch("SetAlertBit")]
        public async Task<IActionResult> SetAlertBit(int Id, bool Set)
        {
            Inventory inventory;
            inventory = await _repo.GetInventory(Id);

            if (inventory.AlertBit != Set)
            {
                inventory.AlertBit = Set;
                var updatedInventory = await _repo.UpdateInventory(inventory);
            }

            //created at root status code
            return StatusCode(201);
        } */
    }
}