namespace CheckIT.API.Dtos
{
    public class LineItemData
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ItemId { get; set; }
    }
}