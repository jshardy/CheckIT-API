using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

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
        //public bool AlertBit { get; set; }

        public Inventory InventoryDataBindOBJ => new Inventory
        {
            UPC = InventoryDataBindOBJ.UPC,
            Price = InventoryDataBindOBJ.Price,
            Name = InventoryDataBindOBJ.Name,
            Description = InventoryDataBindOBJ.Description,
            Quantity = InventoryDataBindOBJ.Quantity,
            //AlertBit = InventoryDataBindOBJ.AlertBit
        };
    }
}