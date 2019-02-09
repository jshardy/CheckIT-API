using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIT.API.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public bool OutgoingInv { get; set; }
        public bool IncomingInv { get; set; }        

        [Column(TypeName="Money")]
        public decimal AmountPaid { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public int InvoiceLineID { get; set; }
        public LineItem InvoiceLine { get; set; }
    }
}