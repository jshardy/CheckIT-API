using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIT.API.Dtos
{
    public class LineItemData
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName="Money")]
        public decimal Price { get; set; }
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
    }
}