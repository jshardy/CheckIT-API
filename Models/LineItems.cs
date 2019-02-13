using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckIT.API.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int QuantitySold { get; set; }

        [Column(TypeName="Money")]
        public decimal Price { get; set; }

        public int LineInvoiceeID { get; set; }
        public LineItem LineInvoice { get; set; }

        public int LineInventoryID { get; set; }
        public LineItem LineInventory { get; set; }
    }
}