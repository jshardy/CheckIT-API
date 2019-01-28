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

namespace CheckIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class InvoiceController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IInvoiceRepository _repo;

        public InvoiceController(IInvoiceRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice(InvoiceDto invoiceDto)
        {
            var invoiceCreate = new Invoice
            {
                InvoiceDate = invoiceDto.InvoiceDate,
                BusinessID  = invoiceDto.BusinessID,
                OutgoingInv = invoiceDto.OutgoingInv,
                IncomingInv = invoiceDto.IncomingInv,
                AmmountPaid = invoiceDto.AmmountPaid
            };

            var createdInvoice = await _repo.AddInvoiceAsync(invoiceCreate);
            return StatusCode(201);
        }

        [HttpPost("ArchiveInvoice/{id}")]
        public async Task<IActionResult> ArchiveInvoice(int id)
        {
            var removedInvoice = await _repo.ArchiveInvoiceAsync(id);
            return StatusCode(201);
        }

        [HttpGet("ReturnOneInvoice/{id}")]
        public async Task<IActionResult> ReturnOneInvoice(int Id)
        {
            var invoiceToFind = await _repo.GetOneInvoiceAsync(Id);
            return Ok(invoiceToFind);
        }

        [HttpGet("ReturnInvoices")]
        public List<Invoice> ReturnInvoices(InvoiceDto invoiceDto, DateTime Date1, DateTime Date2)
        {
            var invoicesToFind = new Invoice
            {
                Id = invoiceDto.Id,
                BusinessID = invoiceDto.BusinessID,
                InvoiceDate = invoiceDto.InvoiceDate,
                OutgoingInv = invoiceDto.OutgoingInv,
                IncomingInv = invoiceDto.IncomingInv,
                AmmountPaid = invoiceDto.AmmountPaid
            };

            var invoiceList = _repo.GetInvoices(invoicesToFind, Date1, Date2);
            return invoiceList;
        }
    }
}