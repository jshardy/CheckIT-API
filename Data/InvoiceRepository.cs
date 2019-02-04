using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;
        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Invoice> AddInvoiceAsync(Invoice invoiceToAdd)
        {
            await _context.Invoices.AddAsync(invoiceToAdd);
            await _context.SaveChangesAsync();

            return invoiceToAdd;
        }

        public async Task<Invoice> ArchiveInvoiceAsync(int invoiceID)
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

        public async Task<Invoice> GetOneInvoiceAsync(int invoiceID)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceID);

            return invoice;
        }

        //Things that are all possible
        //Id, Date range, business Id, outgoing, incomming, if they paid
        //and any of those could be part of one query

        //I need to figure out what will allow me to execute one query based on
        //the data given.

        //one solution to this is bu making a query string and then concatinating
        //it into one string (i think this is the best bet)

        private bool IsDateValid(DateTime DateToCheck)
        {
            if((DateToCheck.Year != 0001 && DateToCheck.Month != 1 && DateToCheck.Day != 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Will return all the entrys in the database, not intended functionality.
        //will work on in the next sprint
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            // var invoiceQuery = await _context.Invoices.Include(items => items.Items).ToListAsync();
            var invoiceQuery = await _context.Invoices.ToListAsync();

            // if(invoice.Id != 0)
            // {
            //     invoiceQuery.Where(x => x.Id == invoice.Id);
            // }

            // if(invoice.BusinessID != 0)
            // {
            //     invoiceQuery.Where(x => x.BusinessID == invoice.BusinessID);
            // }

            // if(IsDateValid(FromDate) && IsDateValid(ToDate) && IsDateValid(invoice.InvoiceDate))
            // {
            //     invoiceQuery.Where(x => FromDate < invoice.InvoiceDate && ToDate > invoice.InvoiceDate);
            // }

            // if(invoice.OutgoingInv == true)
            // {
            //     invoiceQuery.Where(x => x.OutgoingInv == invoice.OutgoingInv);
            // }

            // if(invoice.IncomingInv == true)
            // {
            //     invoiceQuery.Where(x => x.IncomingInv == invoice.IncomingInv);
            // }

            return invoiceQuery;
        }
    }
}