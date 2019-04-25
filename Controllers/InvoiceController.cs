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
        private readonly InvoiceRepository _Irepo;
        private readonly InventoryRepository _Invrepo;
        private readonly IMapper _mapper;
        private readonly AuthRepository _auth;
        private static LastInvoiceData lastInvoice;
        //public InvoiceController(InvoiceRepository Irepo, IMapper mapper, InventoryRepository Invrepo)

        public InvoiceController(InvoiceRepository Irepo, IMapper mapper, InventoryRepository Invrepo, AuthRepository auth)
        {
            _mapper = mapper;
            _Irepo = Irepo;
            _Invrepo = Invrepo;
            _auth = auth;
        }

        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice(InvoiceData iData)
        {
            /*
            User user = await _auth.GetUser(int.Parse(this.User.Identity.Name));

            if (user.UserPermissions.AddInvoice == false)
            {
                return Unauthorized();
            }
            */

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

                var createdInvoice = await _Irepo.AddInvoice(invoiceToCreate);
                lastInvoice.username = this.User.Identity.Name;
                lastInvoice.lastInvoiceId = createdInvoice.Id;

                return StatusCode(201);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("GetLastInvoiceID")]
        public IActionResult GetLastInvoiceID()
        {
            return Ok(lastInvoice);
        }

        [HttpPost("AddLineItem")]
        public async Task<IActionResult> AddLineItem(LineItemData iData)
        {
            if(ModelState.IsValid)
            {
                var lineItemToCreate = new LineItem
                {
                    QuantitySold = iData.Quantity,
                    Price = iData.Price,
                    LineInvoiceID = iData.InvoiceId,
                    LineInvoice = _Irepo.GetOneInvoice(iData.InvoiceId).Result,
                    LineInventoryID = iData.ItemId,
                    LineInventory = _Invrepo.GetInventory(iData.ItemId).Result
                };

                await _Irepo.AddLineItem(lineItemToCreate);

                return StatusCode(201);
            }
            else
            {
                lastInvoice.username = null;
                return BadRequest(ModelState);
            }

        }

        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> ArchiveInvoice(int Id)
        {
            var removedInvoice = await _Irepo.ArchiveInvoice(Id);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReturnOneInvoice(int Id)
        {
            var invoiceToFind = await _Irepo.GetOneInvoice(Id);

            var invoiceToReturn = new InvoiceData
            {
                Id = invoiceToFind.Id,
                InvoiceDate = invoiceToFind.InvoiceDate,
                OutgoingInv = invoiceToFind.OutgoingInv,
                AmountPaid = invoiceToFind.AmountPaid,
                InvoiceCustID = invoiceToFind.InvoiceCustID,
                LineItemList = new List<LineItemData>()
            };

            //var invoiceToReturn = _mapper.Map<InvoiceData>(invoiceToFind);

            foreach (var item in invoiceToFind.InvoicesLineList)
            {
                var newLineitem = new LineItemData
                {
                    Id = item.Id,
                    Quantity = item.QuantitySold,
                    Price = item.Price,
                    ItemId = item.LineInventoryID,
                    InvoiceId = item.LineInvoiceID,
                };

                invoiceToReturn.LineItemList.Add(newLineitem);
            }

            return Ok(invoiceToReturn);
        }

        [HttpGet()]
        public async Task<IActionResult> ReturnInvoices(DateTime InvoiceDate = default(DateTime),
                                                        bool OutgoingInv = false,
                                                        decimal AmmountPaid = -1,
                                                        int CustID = -1)
        {
            var invoiceList = await _Irepo.GetInvoices(InvoiceDate,
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
            /*
            User user = await _auth.GetUser(int.Parse(this.User.Identity.Name));

            if (user.UserPermissions.UpdateInvoice == false)
            {
                return Unauthorized();
            }
            */

            Invoice invoice;
            invoice = await _Irepo.GetOneInvoice(Id);

            if (InvoiceDate != null) invoice.InvoiceDate = InvoiceDate.GetValueOrDefault();
            if (OutgoingInv != null) invoice.OutgoingInv = OutgoingInv.GetValueOrDefault();
            if (AmmountPaid != null) invoice.AmountPaid = AmmountPaid.GetValueOrDefault();
            //cust stuff?

            var updatedInventory = await _Irepo.ModifyInvoice(invoice);
            var modifiedInvoice = await _Irepo.ModifyInvoice(invoice);

            return Ok(modifiedInvoice);
        }

        /*
        [HttpPatch("AddLineItem")]
        public async Task<IActionResult> AddLineItem(LineItemData lineItem)
        {
            User user = await _auth.GetUser(int.Parse(this.User.Identity.Name));

            if (user.UserPermissions.UpdateInvoice == false)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                var lineItemToCreate = new LineItem
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
        */
    }
}