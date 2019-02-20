using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckIT.API.Models;
using CheckIT.API.Models.BindingTargets;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CheckIT.API.Helpers;

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
                                                            decimal Ammount,
                                                            int CustID)
        {


            IQueryable<Invoice> query = _context.Invoices.Include(p => p.InvoicesLineList)
                                                        .Include(p => p.InvoiceCust);

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