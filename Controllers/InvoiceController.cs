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
    [Route("api/[controller]")]
    [ApiController]

    public class InvoiceController : ControllerBase
    {
        private readonly IConfiguration _config;

        public InvoiceController(IConfiguration config)
        {
            _config = config;
        }
    }
}