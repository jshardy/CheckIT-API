using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using CheckIT.API.Models.BindingTargets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace CheckIT.API.Controllers
{
    //[Authorize] <-- you need to put this in any controller made
    //this [Authorize] attribute force the token to be used.
    //IE they don't have to relogin every time.
    //Do not enable it here, this is the "alert" controller.
    //Use [AllowAnonymous] for controllers that don't need auth
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] //this allows us to use [required] and other manditory constraints.
    public class AlertController : ControllerBase
    {
        private readonly AlertRepository _repo;

        public AlertController(AlertRepository repo)
        {
            _repo = repo;
        }
        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("AddAlert")]
        public async Task<IActionResult> AddAlert([FromBody] AlertData alData)
        {
           if(ModelState.IsValid)
           {

                var alertToCreate = new Alert
                {
                    Threshold = alData.Threshold,
                    DateUnder = alData.DateUnder,
                    DateOrdered = alData.DateOrdered,
                    AlertOn = alData.AlertOn
                };

                var createdAlert = await _repo.AddAlert(alertToCreate);

                //created at root status code
                return StatusCode(201);
           }
           else
           {
               return BadRequest(ModelState);
           }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAlert(int Id)//GetAlert(GetByIDDto getAlertDto)
        {
            Alert alert;
            alert = await _repo.GetAlert(Id); //GetAlert(getAlertDto.Id);

            return Ok(alert);
        }

        [HttpGet("GetAllAlerts")]
        public async Task<IActionResult> GetAllAlerts()
        {
            var itemList = await _repo.GetAllAlerts();
            return Ok(itemList);
        }

        [HttpDelete("DeleteAlert")] //[HttpDelete("DeleteAlert/{Id}")]
        public async Task<IActionResult> DeleteAlert(int Id)
        {
            var deletedAlert = await _repo.DeleteAlert(Id);
            return StatusCode(201);
        }

        [HttpPost("UpdateAlert")]
        public async Task<IActionResult> UpdateAlert(AlertDto alertDto)
        {
            Alert alert;
            alert = await _repo.GetAlert(alertDto.Id);

            //probably a much better way to do this
            //possibly something like:
            //PropertyInfo[] properties = alert.GetType().GetProperties();
            //foreach (PropertyInfo pi in properties)
            alert.Threshold = alertDto.Threshold;
            alert.AlertOn = alertDto.AlertOn;
            //alert.AlertBit = updateAlertDto.AlertBit;

            var updatedAlert = await _repo.UpdateAlert(alert);

            //created at root status code
            return StatusCode(201);
        }

        //The following are all methods for modifying the alertbit
        [HttpPatch("CheckAlertBit/{Id}")]
        public async Task<IActionResult> CheckAlertBit(int Id)
        {
            Alert alert;
            alert = await _repo.GetAlert(Id);

            if (alert.AlertOn == false)
            {
                alert.AlertOn = true;
                var updatedAlert = await _repo.UpdateAlert(alert);
            }

            //created at root status code
            return StatusCode(201);
        }

        [HttpPatch("UncheckAlertBit/{Id}")]
        public async Task<IActionResult> UncheckAlertBit(int Id)
        {
            Alert alert;
            alert = await _repo.GetAlert(Id);

            if (alert.AlertOn == true)
            {
                alert.AlertOn = false;
                var updatedAlert = await _repo.UpdateAlert(alert);
            }

            //created at root status code
            return StatusCode(201);
        }

        [HttpPatch("SetAlertBit")]
        public async Task<IActionResult> SetAlertBit(int Id, bool Set)
        {
            Alert alert;
            alert = await _repo.GetAlert(Id);

            if (alert.AlertOn != Set)
            {
                alert.AlertOn = Set;
                var updatedAlert = await _repo.UpdateAlert(alert);
            }

            //created at root status code
            return StatusCode(201);
        }
    }
}