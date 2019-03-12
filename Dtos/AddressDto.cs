using System.ComponentModel.DataAnnotations;

namespace CheckIT.API.Dtos
{
    //Data transfer Object
    public class AddressData
    {
			[Required]
			public string Country { get; set; }
			[Required]
			public string State { get; set; }
			[Required]
			public string ZipCode {get; set; }
			[Required]
			public string City {get; set; }
			[Required]
			public string Street { get; set; }
			public string AptNum { get; set; }
			public int AddressCustID { get; set; }
			public CustomerData AddressCust { get; set;}
    }
}