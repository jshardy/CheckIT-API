using System.Collections.Generic;

namespace CheckIT.API.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public bool IsCompany { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public Address CustAddress {get; set; }

		public int CustInvoiceID { get; set; }
		public Invoice CustInvoice { get; set; }

	}
}
