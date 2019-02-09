using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    public class ItemForUpdateDto
    {
        [Required]
        public int Id { get; set; }
		public int UPC { get; set; }
        [Required]
		public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
		public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool AlertBit { get; set; }
    }
}