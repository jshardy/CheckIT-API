using System;
using System.Collections.Generic;

namespace CheckIT.API.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int BusinessID {get; set;}
        public DateTime InvoiceDate { get; set; }
        public bool OutgoingInv { get; set; }
        public bool IncomingInv { get; set; }
        public decimal AmmountPaid { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}