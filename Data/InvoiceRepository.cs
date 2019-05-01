using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using CheckIT.API.Dtos;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CheckIT.API.Helpers;

namespace CheckIT.API.Data
{
    public class InvoiceRepository
    {
        private readonly DataContext _context;
        private CustRepository _CustRepo;
        private InventoryRepository _InvRepo;
        public InvoiceRepository(DataContext context)
        {
            _context = context;
            _CustRepo = new CustRepository(context);
            _InvRepo = new InventoryRepository(context);
        }
        public async Task<Invoice> AddInvoice(Invoice invoiceToAdd)
        {
            invoiceToAdd.InvoiceCust = _CustRepo.GetCustomer(invoiceToAdd.InvoiceCustID).Result;

            // foreach (var item in invoiceToAdd.InvoicesLineList)
            // {
            //     // var newLineItem = new LineItem
            //     // {
            //     //     QuantitySold = item.Quantity,
            //     //     Price = item.Price,
            //     //     LineInvoiceID = invoiceToAdd.Id,
            //     //     LineInvoice = invoiceToAdd,
            //     //     LineInventoryID = item.ItemId,
            //     //     LineInventory = _InvRepo.GetInventory(item.ItemId).Result
            //     // };

            //     _InvRepo.GetInventory(item.LineInventoryID).Result.InventoryLineList.Add(item);

            //     if(invoiceToAdd.OutgoingInv == true)
            //     {
            //         _InvRepo.GetInventory(item.LineInventoryID).Result.Quantity -= item.QuantitySold;
            //     }
            //     else
            //     {
            //         _InvRepo.GetInventory(item.LineInventoryID).Result.Quantity += item.QuantitySold;
            //     }
            // }

            await _context.Invoices.AddAsync(invoiceToAdd);
            await _context.SaveChangesAsync();

            return invoiceToAdd;
        }

        public async Task<LineItem> AddLineItem(LineItem lineItemToAdd)
        {
            // _InvRepo.GetInventory(lineItemToAdd.LineInventoryID).Result.InventoryLineList.Add(lineItemToAdd);
            // GetOneInvoice(lineItemToAdd.LineInvoiceID).Result.InvoicesLineList.Add(lineItemToAdd);

            await _context.LineItems.AddAsync(lineItemToAdd);
            await _context.SaveChangesAsync();

            return lineItemToAdd;
        }

        public async Task<Invoice> ArchiveInvoice(int invoiceID)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceID);

            if(invoice == null)
            {
                return null;
            }
            else
            {
                _context.Invoices.Remove(invoice);
            }

            await _context.SaveChangesAsync();

            return invoice;
        }

        public async Task<Invoice> ModifyInvoice(int invoiceID)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceID);

            return invoice;
        }

        public async Task<Invoice> ModifyInvoice(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }

        public async Task<Invoice> GetOneInvoice(int invoiceID)
        {
            var invoice = await _context.Invoices.Include(p => p.InvoicesLineList)
                                                    //.ThenInclude(p => p.LineInventory)
                                                 .Include(p => p.InvoiceCust)
                                                    .ThenInclude(p => p.CustAddress)
                                                 .FirstOrDefaultAsync(x => x.Id == invoiceID);

            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetInvoices(DateTime InvDate, 
                                                            bool Out, 
                                                            decimal Ammount,
                                                            int CustID)
        {


            IQueryable<Invoice> query = _context.Invoices;

            if(InvDate > DateTime.MinValue)
            {
                query = query.Where(p => p.InvoiceDate.ToShortDateString() == InvDate.ToShortDateString());
            }

            if(CustID!= -1)
            {
                query = query.Where(p => p.InvoiceCust.Id == CustID);
            }

            if(Out != false)
            {
                query = query.Where(p => p.OutgoingInv == Out);
            }

            if(Ammount != -1)
            {
                query = query.Where(p => p.AmountPaid == Ammount);
            }

            return await query.ToListAsync();
        }
    }
}