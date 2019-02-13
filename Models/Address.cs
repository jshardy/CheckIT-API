using System.Collections.Generic;

namespace CheckIT.API.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string ZipCode {get; set; }
		public string City {get; set; }
		public string Street { get; set; }
		public string AptNum { get; set; }
		public bool DefaultAddress { get; set; }

		public int AddressCustID { get; set; }
		public Customer AddressCust { get; set;}
	}
}
