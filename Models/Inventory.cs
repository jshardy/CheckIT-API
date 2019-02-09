using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Collections.Generic;

namespace CheckIT.API.Models
{
    public class Inventory
    {
        [Required]
        public int Id { get; set; }
        [Required]
		public int UPC { get; set; }

        [Column(TypeName="Money")]
		public decimal Price { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
        public int Quantity { get; set; }
        public bool Archived { get; set; }

        public int InventoryLocationID { get; set; }
        public Location InventoryLocation { get; set; }
        public int InventoryAlertID { get; set; }
        public Alert InventoryAlert { get; set; }
        public int InventoryLineID { get; set; }
        public LineItem InventoryLine { get; set; }
    }
}