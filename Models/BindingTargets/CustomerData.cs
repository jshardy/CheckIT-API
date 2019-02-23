using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class CustomerData
    {
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		[Required]
		public bool IsCompany { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		[Required]
        public AddressData CustAddress { get; set;}
    }
}