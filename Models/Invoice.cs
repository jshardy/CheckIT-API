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

        [Column(TypeName="Money")]
        public decimal AmountPaid { get; set; }
        public int InvoiceCustID { get; set; }
		public Customer InvoiceCust { get; set; }
        public List<LineItem> InvoicesLineList { get; set; }
    }
}