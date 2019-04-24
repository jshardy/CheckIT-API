namespace CheckIT.API.JSObjects
{
    public class JSItem
    {
        public int Id { get; set; }
        public string UPC { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int LocationId { get; set; }
        public int AlertId { get; set; }
    }
}