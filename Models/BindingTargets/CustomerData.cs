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
		public Address CustAddress { get; set; }

		public int CustInvoiceID { get; set; }
		public Invoice CustInvoice { get; set; }

        public Customer CustomerDataBindOBJ => new Customer
        {
            FirstName = CustomerDataBindOBJ.FirstName,
            LastName = CustomerDataBindOBJ.LastName,
            CompanyName = CustomerDataBindOBJ.CompanyName,
            IsCompany = CustomerDataBindOBJ.IsCompany,
            PhoneNumber = CustomerDataBindOBJ.PhoneNumber,
            Email = CustomerDataBindOBJ.Email,
            CustAddress = CustomerDataBindOBJ.CustAddress,
            CustInvoiceID = CustomerDataBindOBJ.CustInvoiceID,
            CustInvoice = CustomerDataBindOBJ.CustInvoice
        };
    }
}