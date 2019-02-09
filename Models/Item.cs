using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

namespace CheckIT.API.Models
{
    public class Item
    {
        public int Id { get; set; }
		public int UPC { get; set; }

        [Column(TypeName="Money")]
		public decimal Price { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
        public int Quantity { get; set; }
        public bool AlertBit { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }
        public bool Archived { get; set; }
    }
}