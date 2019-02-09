using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class InvoiceData
    {
        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "The Business ID must be entered!")]
        //public int BusinessID {get; set;}
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public bool OutgoingInv { get; set; }
        [Required]
        public bool IncomingInv { get; set; }
        public decimal AmmountPaid { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }

        public Invoice InvoiceDataBindOBJ => new Invoice
        {
            // I will need to impliment this differently once we get
            // the Business Model/Controller made
            //BusinessID = InvoiceDataBindOBJ.BusinessID,
            InvoiceDate = InvoiceDataBindOBJ.InvoiceDate,
            OutgoingInv = InvoiceDataBindOBJ.OutgoingInv,
            IncomingInv = InvoiceDataBindOBJ.IncomingInv,
            AmmountPaid = InvoiceDataBindOBJ.AmmountPaid,
            LineItems = InvoiceDataBindOBJ.LineItems
        };
    }
}