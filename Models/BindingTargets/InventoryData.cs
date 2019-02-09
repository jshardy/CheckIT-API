namespace CheckIT.API.Models.BindingTargets
{
    public class InventoryData
    {
		public int UPC { get; set; }
        [Required]
		public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
		public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool AlertBit { get; set; }

        public Inventory ItemDataBindOBJ => new Inventory
        {
            UPC = ItemDataBindOBJ.UPC,
            Price = ItemDataBindOBJ.Price,
            Name = ItemDataBindOBJ.Name,
            Description = ItemDataBindOBJ.Description,
            Quantity = ItemDataBindOBJ.Quantity,
            AlertBit = ItemDataBindOBJ.AlertBit
        };
    }
}