namespace CheckIT.API.Models
{
    public class Item
    {
        public int Id { get; set; }
		public int UPC { get; set; }
		public float Price { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
        //public int Quantity { get; set; }
    }
}