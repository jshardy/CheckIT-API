namespace CheckIT.API.Dtos
{
    public class LineItemData
    {
        public int Id { get; set; }
        // TODO: Add money attribute
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
    }
}