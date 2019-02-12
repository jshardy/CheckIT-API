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
        public bool IncomingInv { get; set; }
        public decimal AmountPaid { get; set; }
        public ICollection<Customer> InvoiceCustomerList { get; set; }
        public int InvoiceLineID { get; set; }
        public LineItem InvoiceLine { get; set; }

        public Invoice InvoiceDataBindOBJ => new Invoice
        {
            // I will need to impliment this differently once we get
            // the Business Model/Controller made
            InvoiceCustomerList = InvoiceDataBindOBJ.InvoiceCustomerList,
            InvoiceDate = InvoiceDataBindOBJ.InvoiceDate,
            OutgoingInv = InvoiceDataBindOBJ.OutgoingInv,
            IncomingInv = InvoiceDataBindOBJ.IncomingInv,
            AmountPaid = InvoiceDataBindOBJ.AmountPaid,
            InvoiceLine = InvoiceDataBindOBJ.InvoiceLine,
            InvoiceLineID = InvoiceDataBindOBJ.InvoiceLineID
        };
    }
}