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
            if((DateToCheck.Year != 0 && DateToCheck.Month != 0 && DateToCheck.Day != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int NumOfParam(Invoice invoice, DateTime FromDate, DateTime ToDate)
        {
            var paramCount = 0;

            if(invoice.BusinessID != 1)
            {
                paramCount++;
            }

            if(IsDateValid(invoice.InvoiceDate))
            {
                paramCount++;
            }

            if(invoice.OutgoingInv)
            {
                paramCount++;
            }

            if(invoice.IncomingInv)
            {
                paramCount++;
            }

            return paramCount;
        }

        //This function is not Async. If there is a better way to make this async then please make changes
        public List<Invoice> GetInvoicesAsync(Invoice invoice, DateTime FromDate, DateTime ToDate)
        {
            var queryString = "";

            var paramNum = NumOfParam(invoice, FromDate, ToDate);

            if(invoice.BusinessID != -1)
            {
                queryString += "BusinessID = " + invoice.BusinessID.ToString() + "\n";

                if(paramNum > 0)
                {
                    queryString += "AND \n";
                    paramNum--;
                }
            }

            if(IsDateValid(FromDate) && IsDateValid(ToDate) && IsDateValid(invoice.InvoiceDate))
            {
                queryString += "InvoiceDate BETWEEN " + FromDate.ToShortDateString() + " AND " + ToDate.ToShortDateString() + "\n";

                if(paramNum > 0)
                {
                    queryString += "AND \n";
                    paramNum--;
                }
            }

            if(invoice.OutgoingInv == true)
            {
                queryString += "OutgoingInv == true \n";

                if(paramNum > 0)
                {
                    queryString += "AND \n";
                    paramNum--;
                }
            }

            if(invoice.IncomingInv == true)
            {
                queryString += "IncomingInv == true \n";

                if(paramNum > 0)
                {
                    queryString += "AND \n";
                    paramNum--;
                }
            }

            var invoiceList = _context.Invoices.FromSql("SELECT * FROM Invoices WHERE " + queryString).ToList();

            return invoiceList;
        }
    }
}