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
using CheckIT.API.Helpers;

namespace CheckIT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceRepository _repo;

        public InvoiceController(InvoiceRepository repo)
        {
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
                    OutgoingInv = iData.OutgoingInv,
                    IncomingInv = iData.IncomingInv,
                    AmountPaid = iData.AmountPaid
                };

                var createdInvoice = await _repo.AddInvoice(invoiceCreate);

                return StatusCode(201);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> ArchiveInvoice(int Id)
        {
            var removedInvoice = await _repo.ArchiveInvoice(Id);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnOneInvoice(int Id)
        {
            var invoiceToFind = await _repo.GetOneInvoice(Id);
            return Ok(invoiceToFind);
        }

        [HttpGet()]
        public async Task<IActionResult> ReturnInvoices(DateTime InvoiceDate = default(DateTime),
                                                        bool OutgoingInv = false,
                                                        bool IncomingInv = false,
                                                        decimal AmmountPaid = -1,
                                                        int CustID = -1,
                                                        int InvoiceLineId = -1)
        {
            var invoiceList = await _repo.GetInvoices(InvoiceDate,
                                                    OutgoingInv,
                                                    IncomingInv,
                                                    AmmountPaid,
                                                    CustID,
                                                    InvoiceLineId);
            return Ok(invoiceList);
        }

        // [HttpPut("FillTable")]
        // public IActionResult FillTable()
        // {
        //     //calls the DataMocker classes FillTable method
        //     _repo.FillMockTable();
        //     return StatusCode(201);
        // }

        // [HttpPut("ClearTable")]
        // public IActionResult ClearTable()
        // {
        //     //calls the DataMocker classes ClearTable method
        //     _repo.ClearMockData();
        //     return StatusCode(201);
        // }
    }
}