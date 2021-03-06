using System.Collections.Generic;

namespace CheckIT.API.Models
{
    public class Location
    {
        public int Id { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Inventory> InventoryLocList { get; set; }
    }
}