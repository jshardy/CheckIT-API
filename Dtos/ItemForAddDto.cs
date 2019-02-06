using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    public class ItemForAddDto
    {
        //public int Id { get; set; }
		public int UPC { get; set; }
		public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
		public string Description { get; set; }
        public int Quantity { get; set; }
        public bool AlertBit { get; set; }
    }
}