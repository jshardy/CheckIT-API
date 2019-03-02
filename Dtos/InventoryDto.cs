using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    public class InventoryData
    {
        public int Id {get; set; }
		public int UPC { get; set; }
        [Required]
		public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
		public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int InventoryLocationID { get; set; }
        public int InventoryAlertID { get; set; }
    }
}