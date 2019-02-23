using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class InvoiceData
    {
        public DateTime InvoiceDate { get; set; }
        public bool OutgoingInv { get; set; }
        public decimal AmountPaid { get; set; }
        public int InvoiceCustID { get; set; }
		public Customer InvoiceCust { get; set; }        
        public IEnumerable<LineItem> InvoicesLineList { get; set; }
    }
}