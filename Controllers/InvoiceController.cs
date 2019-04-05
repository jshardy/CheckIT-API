using System;
using AutoMapper;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceRepository _repo;
        private readonly IMapper _mapper;

        public InvoiceController(InvoiceRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice(InvoiceData iData)
        {
            if (ModelState.IsValid)
            {
                var invoiceToCreate = new Invoice
                {
                    InvoiceDate = iData.InvoiceDate,
                    OutgoingInv = iData.OutgoingInv,
                    AmountPaid = iData.AmountPaid,
                    InvoiceCustID = iData.InvoiceCustID
                };

                //var invoiceToCreate = _mapper.Map<Invoice>(iData);

                var createdInvoice = await _repo.AddInvoice(invoiceToCreate);



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

            var invoiceToReturn = _mapper.Map<InvoiceData>(invoiceToFind);

            return Ok(invoiceToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> ReturnInvoices(DateTime InvoiceDate = default(DateTime),
                                                        bool OutgoingInv = false,
                                                        decimal AmmountPaid = -1,
                                                        int CustID = -1)
        {
            var invoiceList = await _repo.GetInvoices(InvoiceDate,
                                                    OutgoingInv,
                                                    AmmountPaid,
                                                    CustID);
            return Ok(invoiceList);
        }

        [HttpPatch()]
        public async Task<IActionResult> ModifyInvoice(int Id,
                                                        DateTime? InvoiceDate,
                                                        bool? OutgoingInv,
                                                        decimal? AmmountPaid,
                                                        int? CustID)
        {
            Invoice invoice;
            invoice = await _repo.GetOneInvoice(Id);

            if (InvoiceDate != null) invoice.InvoiceDate = InvoiceDate.GetValueOrDefault();
            if (OutgoingInv != null) invoice.OutgoingInv = OutgoingInv.GetValueOrDefault();
            if (AmmountPaid != null) invoice.AmountPaid = AmmountPaid.GetValueOrDefault();
            //cust stuff?

            var updatedInventory = await _repo.ModifyInvoice(invoice);


            var modifiedInvoice = await _repo.ModifyInvoice(invoice);

            return Ok(modifiedInvoice);
        }
    }
}