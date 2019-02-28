using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class InvoiceData
    {
        //TODO: Add money tag.
        public DateTime InvoiceDate { get; set; }
        public bool OutgoingInv { get; set; }
        public decimal AmountPaid { get; set; }
        public int InvoiceCustID { get; set; }
        public ICollection<LineItemData> ItemList { get; set; }
    }
}