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
    //Do not enable it here, this is the "alert" controller.
    //Use [AllowAnonymous] for controllers that don't need auth
    [Authorize]
    [Route("api/[controller]")]
    [ApiController] //this allows us to use [required] and other manditory constraints.
    public class AlertController : ControllerBase
    {
        private readonly AlertRepository _repo;
        private readonly AuthRepository _auth;

        public AlertController(AlertRepository repo, AuthRepository auth)
        {
            _repo = repo;
            _auth = auth;
        }

        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("AddAlert")]
        public async Task<IActionResult> AddAlert([FromBody] AlertData alData)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.AddAlert == false)
            {
                return Unauthorized();
            }

            if(ModelState.IsValid)
            {
                var alertToCreate = new Alert
                {
                    Threshold = alData.Threshold,
                    DateUnder = alData.DateUnder,
                    DateOrdered = alData.DateOrdered,
                    AlertOn = alData.AlertOn,
                    AlertTriggered = alData.AlertTriggered
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
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewAlert == false)
            {
                return Unauthorized();
            }

            Alert alert;
            alert = await _repo.GetAlert(Id); //GetAlert(getAlertDto.Id);

            return Ok(alert);
        }

        [HttpGet("GetAllAlerts")]
        public async Task<IActionResult> GetAllAlerts()
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewAlert == false)
            {
                return Unauthorized();
            }

            var alertList = await _repo.GetAllAlerts();
            return Ok(alertList);
        }

        [HttpGet("GetTriggeredAlerts")]
        public async Task<IActionResult> GetTriggeredAlerts()
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewAlert == false)
            {
                return Unauthorized();
            }

            List<Alert> triggeredAlerts = new List<Alert>();

            var alertList = await _repo.GetAllAlerts();

            foreach (var alert in alertList)
            {
                if (alert.AlertTriggered == true && alert.AlertOn == true)
                {
                    triggeredAlerts.Add(alert);
                }
            }

            return Ok(triggeredAlerts);
        }

        [HttpGet("GetTriggeredAlerts")]
        public async Task<IActionResult> GetNonTriggeredAlerts()
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.ViewAlert == false)
            {
                return Unauthorized();
            }

            List<Alert> nontriggeredAlerts = new List<Alert>();

            var alertList = await _repo.GetAllAlerts();

            foreach (var alert in alertList)
            {
                if (alert.AlertTriggered == false)
                {
                    nontriggeredAlerts.Add(alert);
                }
            }

            return Ok(nontriggeredAlerts);
        }


        [HttpDelete("DeleteAlert")] //[HttpDelete("DeleteAlert/{Id}")]
        public async Task<IActionResult> DeleteAlert(int Id)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.DeleteAlert == false)
            {
                return Unauthorized();
            }

            var deletedAlert = await _repo.DeleteAlert(Id);
            return StatusCode(201);
        }

        [HttpPost("UpdateAlert")]
        public async Task<IActionResult> UpdateAlert(AlertData alertData)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.UpdateAlert == false)
            {
                return Unauthorized();
            }

            Alert alert;
            alert = await _repo.GetAlert(alertData.Id);

            //probably a much better way to do this
            //possibly something like:
            //PropertyInfo[] properties = alert.GetType().GetProperties();
            //foreach (PropertyInfo pi in properties)
            alert.Threshold = alertData.Threshold;
            alert.AlertOn = alertData.AlertOn;
            //alert.AlertBit = updateAlertDto.AlertBit;

            var updatedAlert = await _repo.UpdateAlert(alert);

            //created at root status code
            return StatusCode(201);
        }

        //The following are all methods for modifying the alertbit
        [HttpPatch("CheckAlertBit/{Id}")]
        public async Task<IActionResult> CheckAlertBit(int Id)
        {
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.UpdateAlert == false)
            {
                return Unauthorized();
            }

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
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.UpdateAlert == false)
            {
                return Unauthorized();
            }

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
            User user = await _auth.GetUser(this.User.Identity.Name);
            Permissions permissions = await _auth.GetPermissions(user.Id);
            
            if (permissions.UpdateAlert == false)
            {
                return Unauthorized();
            }

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