using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
    public class AddressData
    {
		public string Country { get; set; }
		public string State { get; set; }
		public string ZipCode {get; set; }
		public string City {get; set; }
		public string Street { get; set; }
		public string AptNum { get; set; }
		public bool DefaultAddress { get; set; }

		//public IList<Customer> Customers { get; set; }

        public Address AddressDataBindOBJ => new Address
        {
            Country = AddressDataBindOBJ.Country,
            State = AddressDataBindOBJ.State,
            ZipCode = AddressDataBindOBJ.ZipCode,
            City = AddressDataBindOBJ.City,
            Street = AddressDataBindOBJ.Street,
            AptNum = AddressDataBindOBJ.AptNum,
            DefaultAddress = AddressDataBindOBJ.DefaultAddress
        };
    }
}