using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using CheckIT.API.Models.BindingTargets;
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
        public async Task<Invoice> AddInvoice(Invoice invoiceToAdd)
        {
            await _context.Invoices.AddAsync(invoiceToAdd);
            await _context.SaveChangesAsync();

            return invoiceToAdd;
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

        public async Task<Invoice> GetOneInvoice(int invoiceID)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceID);

            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetInvoices(DateTime InvDate, 
                                                            bool Out, 
                                                            bool In, 
                                                            decimal Ammount)
        {


            IQueryable<Invoice> query = _context.Invoices;

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

            return await query.Include(p => p.InvoiceLine).ToListAsync();
        }
    }
}