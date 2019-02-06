namespace CheckIT.API.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int QuantitySold { get; set; }
        public decimal Price { get; set; }

        public int InvoiceID { get; set; }
        public Invoice invoice { get; set; }

        public int ItemID { get; set; }
        public Item item { get; set; }
    }
}