using System;
using System.Collections.Generic;
using System.Linq;
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
    public class AuthController : ControllerBase
    {
        private readonly AuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(AuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }
        //http://localhost:5000/api/Register
        //dto object to convert json to class
        [HttpPost("Register")]
        // [FromBody] this is infered for UserForRegisterDto by [ApiController]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //Must use this if don't use [ApiController]
            //if(!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            //created at root status code
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForRegisterDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
    
            //User not found return unauthorized.
            if (userFromRepo == null)
                return Unauthorized();


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }

        public async Task<User> GetUser(int Id)
        {
            User user;
            user = await _repo.GetUser(Id);

            return user;
        }

        /*
        Permission Levels:
            -1) Custom
            0) Admin (Can do everything include managing permissions)
            1) Manager (Can do everything except managing permissions)
            2) Employee (Can view, add, and edit most things)
            3) Veiw Only (Can view most things)
            4) Null (no permissions)
        */
        [HttpPatch("SetPermissions")]
        public async Task<IActionResult> SetPermissionsPreset(UserDto user)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            /*
            User user;
            
            if (user.UserPermissions.SetUserPermissions == false)
            {
                return Unauthorized();
            }
            */
            Permissions permissions = new Permissions();

            permissions.Level = user.PermissionLevel;

            if (user.PermissionLevel == 0 || user.PermissionLevel == 1) //Admin or Manager
            {
                if (user.PermissionLevel == 0) //Admin
                {
                    permissions.ViewUserPermissions = true;
                    permissions.SetUserPermissions = true;
                }
                else //Manager
                {
                    permissions.ViewUserPermissions = false;
                    permissions.SetUserPermissions = false;
                }
                permissions.AddAlert = true;
                permissions.UpdateAlert = true;
                permissions.ViewAlert = true;
                permissions.DeleteAlert = true;

                permissions.AddCustomer = true;
                permissions.UpdateCustomer = true;
                permissions.ViewCustomer = true;
                permissions.DeleteCustomer = true;

                permissions.AddIventory = true;
                permissions.UpdateInventory = true;
                permissions.ViewInventory = true;
                permissions.ArchiveIventory = true;

                permissions.AddInvoice = true;
                permissions.UpdateInvoice = true;
                permissions.ArchiveInvoice = true;
                permissions.ViewInvoice = true;

                permissions.AddLocation = true;
                permissions.DeleteLocation = true;
                permissions.ViewLocation = true;
            }
            else if (user.PermissionLevel == 2) //Employee
            {
                permissions.ViewUserPermissions = false;
                permissions.SetUserPermissions = false;

                permissions.AddAlert = true;
                permissions.UpdateAlert = true;
                permissions.ViewAlert = true;
                permissions.DeleteAlert = true;

                permissions.AddCustomer = true;
                permissions.UpdateCustomer = true;
                permissions.ViewCustomer = true;
                permissions.DeleteCustomer = true;

                permissions.AddIventory = true;
                permissions.UpdateInventory = true;
                permissions.ViewInventory = true;
                permissions.ArchiveIventory = false;

                permissions.AddInvoice = true;
                permissions.UpdateInvoice = true;
                permissions.ArchiveInvoice = false;
                permissions.ViewInvoice = true;

                permissions.AddLocation = true;
                permissions.DeleteLocation = true;
                permissions.ViewLocation = true;
            }
            else if (user.PermissionLevel == 3) //View Only
            {
                permissions.ViewUserPermissions = false;
                permissions.SetUserPermissions = false;

                permissions.AddAlert = false;
                permissions.UpdateAlert = false;
                permissions.ViewAlert = true;
                permissions.DeleteAlert = false;

                permissions.AddCustomer = false;
                permissions.UpdateCustomer = false;
                permissions.ViewCustomer = true;
                permissions.DeleteCustomer = false;

                permissions.AddIventory = false;
                permissions.UpdateInventory = false;
                permissions.ViewInventory = true;
                permissions.ArchiveIventory = false;

                permissions.AddInvoice = false;
                permissions.UpdateInvoice = false;
                permissions.ArchiveInvoice = false;
                permissions.ViewInvoice = true;

                permissions.AddLocation = false;
                permissions.DeleteLocation = false;
                permissions.ViewLocation = true;
            }
            else //Null/No Permissions
            {
                permissions.ViewUserPermissions = false;
                permissions.SetUserPermissions = false;

                permissions.AddAlert = false;
                permissions.UpdateAlert = false;
                permissions.ViewAlert = false;
                permissions.DeleteAlert = false;

                permissions.AddCustomer = false;
                permissions.UpdateCustomer = false;
                permissions.ViewCustomer = false;
                permissions.DeleteCustomer = false;

                permissions.AddIventory = false;
                permissions.UpdateInventory = false;
                permissions.ViewInventory = false;
                permissions.ArchiveIventory = false;

                permissions.AddInvoice = false;
                permissions.UpdateInvoice = false;
                permissions.ArchiveInvoice = false;
                permissions.ViewInvoice = false;

                permissions.AddLocation = false;
                permissions.DeleteLocation = false;
                permissions.ViewLocation = false;
            }

            if (await _repo.ModifyUserPermissions(user.Id, permissions))
                return StatusCode(201);

            return BadRequest("Could not find User");
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            /*
            User user;
            
            if (user.UserPermissions.ViewUserPermissions == false)
            {
                return Unauthorized();
            }
            */

            var userList = await _repo.GetAllUsers();

            List<UserDto> userListToReturn = new List<UserDto>();

            foreach (var user in userList)
            {
                userListToReturn.Add(
                    new UserDto{
                        Id = user.Id,
                        Username = user.Username,
                        PermissionLevel = user.UserPermissions.Level
                    }
                );
            }

            return Ok(userListToReturn);
        }

    }
}