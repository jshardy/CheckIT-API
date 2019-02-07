using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckIT.API.Data
{
    public class InvoiceRepository
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

        //Will return all the entrys in the database, not intended functionality.
        //will work on in the next sprint
        public async Task<IEnumerable<Invoice>> GetInvoices(int BusID, 
                                                            DateTime InvDate, 
                                                            bool Out, 
                                                            bool In, 
                                                            decimal Ammount)
        {


            IQueryable<Invoice> query = _context.Invoices;

            if(BusID != -1)
            {
                query = query.Where(p => p.BusinessID == BusID);
            }

            if(InvDate > DateTime.MinValue)
            {
                query = query.Where(p => p.InvoiceDate.ToShortDateString() == InvDate.ToShortDateString());
            }

            if(Out != false)
            {
                query = query.Where(p => p.OutgoingInv == Out);
            }

            if(In != false)
            {
                query = query.Where(p => p.IncomingInv == In);
            }

            if(Ammount != -1)
            {
                query = query.Where(p => p.AmmountPaid == Ammount);
            }

            return await query.Include(p => p.LineItems).ToListAsync();
        }
    }
}