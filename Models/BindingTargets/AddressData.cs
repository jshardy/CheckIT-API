using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheckIT.API.Models;

namespace CheckIT.API.Models.BindingTargets
{
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
			[Required]
			public string AptNum { get; set; }
			[Required]
			public bool DefaultAddress { get; set; }
    }
}