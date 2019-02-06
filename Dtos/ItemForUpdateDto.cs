using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    public class ItemForUpdateDto
    {
        [Required]
        public int Id { get; set; }
		public int UPC { get; set; }
		public decimal Price { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
        public int Quantity { get; set; }
    }
}