using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class CustomerData
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public bool IsCompany { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
        public AddressData CustAddress { get; set;}
    }
}