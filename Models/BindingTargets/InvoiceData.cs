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

        public Invoice InvoiceDataBindOBJ => new Invoice
        {
            // I will need to impliment this differently once we get
            // the Business Model/Controller made
            InvoiceCustID = InvoiceDataBindOBJ.InvoiceCustID,
            InvoicesLineList = InvoiceDataBindOBJ.InvoicesLineList,
            InvoiceDate = InvoiceDataBindOBJ.InvoiceDate,
            OutgoingInv = InvoiceDataBindOBJ.OutgoingInv,
            AmountPaid = InvoiceDataBindOBJ.AmountPaid
        };
    }
}