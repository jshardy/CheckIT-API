namespace CheckIT.API.Models
{
	public class Address
	{
		public int ID { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string ZipCode {get; set; }
		public string Street { get; set; }
		public string AptNum { get; set; }
	}
}
