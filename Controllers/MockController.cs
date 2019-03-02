using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CheckIT.API.Helpers;

namespace CheckIT.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MockDataController : ControllerBase
    {
        private readonly MockRepository _repo;

        public MockDataController(MockRepository repo)
        {
            _repo = repo;
        }

        [HttpPut("FillTable")]
        public IActionResult FillTable()
        {
            //calls the DataMocker classes FillTable method
            _repo.FillMockTable();
            return StatusCode(201);
        }

        [HttpPut("ClearTable")]
        public IActionResult ClearTable()
        {
            //calls the DataMocker classes ClearTable method
            _repo.ClearMockData();
            return StatusCode(201);
        }
    }
}