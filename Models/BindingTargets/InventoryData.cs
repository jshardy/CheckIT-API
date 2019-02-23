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
    }
}