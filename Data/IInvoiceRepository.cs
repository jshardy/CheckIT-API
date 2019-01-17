using System;
using System.Threading.Tasks;
using CheckIT.API.Models;

namespace CheckIT.API.Data
{

    public interface IInvoiceRepository
    {
        Task<Invoice> AddInvoiceAsync (Invoice invoiceToAdd);
        Task<Invoice> ArchiveInvoiceAsync (int invoiceID);
        Task<Invoice> GetOneInvoiceAsync (int invoiceID);
        Task<Invoice> GetInvoicesAsync (Invoice invoice, DateTime StartDate, DateTime EndDate);
    }
}