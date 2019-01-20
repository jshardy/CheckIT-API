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
        public float AmmountPaid { get; set; }
        public ICollection<Item> Items  { get; set; }
    }
}