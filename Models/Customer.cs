namespace CheckIT.API.Models
{
	public class Customer
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public Address Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
