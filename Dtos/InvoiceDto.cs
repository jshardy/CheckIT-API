using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class InvoiceData
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public bool OutgoingInv { get; set; }
        public decimal AmountPaid { get; set; }
        public int InvoiceCustID { get; set; }
        public List<LineItemData> LineItemList { get; set; }
    }
}