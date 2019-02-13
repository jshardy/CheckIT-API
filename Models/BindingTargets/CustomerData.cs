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
		//public int CustAddressID { get; set; }
		public Address CustAddress { get; set;}

		//public IEnumerable<Address> CustAddresses {get; set; }
		public IEnumerable<Customer> InvoiceCustomerList { get; set; }

        public Customer CustomerDataBindOBJ => new Customer
        {
            FirstName = CustomerDataBindOBJ.FirstName,
            LastName = CustomerDataBindOBJ.LastName,
            CompanyName = CustomerDataBindOBJ.CompanyName,
            IsCompany = CustomerDataBindOBJ.IsCompany,
            PhoneNumber = CustomerDataBindOBJ.PhoneNumber,
            Email = CustomerDataBindOBJ.Email,
            //CustAddressID = CustomerDataBindOBJ.CustAddressID,
            CustAddress = CustomerDataBindOBJ.CustAddress,
            CustomerInvoiceList = CustomerDataBindOBJ.CustomerInvoiceList
        };
    }
}