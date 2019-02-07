using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CheckIT.API.Data;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using CheckIT.API.Models.BindingTargets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CheckIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly InvoiceRepository _repo;

        public InvoiceController(InvoiceRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceData iData)
        {
            if (ModelState.IsValid) 
            {
                var invoiceCreate = new Invoice
                {
                    InvoiceDate = iData.InvoiceDate,
                    BusinessID  = iData.BusinessID,
                    OutgoingInv = iData.OutgoingInv,
                    IncomingInv = iData.IncomingInv,
                    AmmountPaid = iData.AmmountPaid
                };

                var createdInvoice = await _repo.AddInvoiceAsync(invoiceCreate);

                return StatusCode(201);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ArchiveInvoice(int Id)
        {
            var removedInvoice = await _repo.ArchiveInvoiceAsync(Id);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnOneInvoice(int Id)
        {
            var invoiceToFind = await _repo.GetOneInvoiceAsync(Id);
            return Ok(invoiceToFind);
        }

        [HttpGet()]
        public async Task<IActionResult> ReturnInvoices(int BusinessID = -1, 
                                                        DateTime InvoiceDate = default(DateTime), 
                                                        bool OutgoingInv = false, 
                                                        bool IncomingInv = false, 
                                                        decimal AmmountPaid = -1)
        {
            var invoiceList = await _repo.GetInvoices(BusinessID, 
                                                      InvoiceDate,
                                                      OutgoingInv,
                                                      IncomingInv,
                                                      AmmountPaid);
            return Ok(invoiceList);
        }
    }
}