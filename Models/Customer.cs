namespace CheckIT.API.Models
{
	public class Customer
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		// This does not allow cascading delete.
		// You will now need to make a separate delete for the address also.
		//public int AddressID { get; set; }
		public Address Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
