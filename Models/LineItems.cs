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

        public IEnumerable<Invoice> Invoices { get; set; }

        public IEnumerable<Inventory> Inventories {get; set; } 
    }
}