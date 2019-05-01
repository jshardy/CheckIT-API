using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CheckIT.API.Models;
using checkit.api.Models.Quickbook_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CheckIT.API.Data
{
    public class QuickRepository
    {
        private readonly DataContext _context;
        private CustRepository _CustRepo;
        private InventoryRepository _InvRepo;
        static HttpClient client = new HttpClient();
        static string baseURL = "https://sandbox-quickbooks.api.intuit.com/v3/company/";
        static string minorVersion = "57";


        public QuickRepository(DataContext context)
        {
            _context = context;
            _CustRepo = new CustRepository(context);
            _InvRepo = new InventoryRepository(context);
        }

        static async Task<HttpContent> CreateCustomerAsync(string idToken, string realmID, QB_Customer customer)
        {
            string CustomerURL = baseURL + realmID + "/customer?minorversion=" + minorVersion;

            client.SetBearerToken(idToken);
            HttpResponseMessage response = await client.PostAsJsonAsync(CustomerURL, customer);

            System.Console.WriteLine("\n==========\nRequest: " + response.RequestMessage + "\n==========\n");
            response.EnsureSuccessStatusCode();

            return response.Content;//.Headers.Location;
        }

        static async Task<HttpContent> CreateItemAsync(string idToken, string realmID, QB_Item item)
        {
            string ItemURL = baseURL + realmID + "item?minorversion=" + minorVersion;

            HttpResponseMessage response = await client.PostAsJsonAsync(ItemURL, item);
            response.EnsureSuccessStatusCode();

            return response.Content;//.Headers.Location;
        }

        static async Task<HttpContent> CreateInvoiceAsync(string idToken, string realmID, QB_Invoice inv)
        {
            string ItemURL = baseURL + realmID + "invoice?minorversion=" + minorVersion;

            HttpResponseMessage response = await client.PostAsJsonAsync(ItemURL, inv);
            response.EnsureSuccessStatusCode();

            return response.Content;//.Headers.Location;
        }

        public async Task<QB_Invoice> SendInvoice(Invoice inv_convert, string realmID, string idToken)
        {
            var curr_customer  = inv_convert.InvoiceCust;
            var curr_address = inv_convert.InvoiceCust.CustAddress;

            var new_Customer = new QB_Customer
            {
                BillAddr = new CustBilling
                {
                    Line1 = curr_address.Street,
                    City = curr_address.City,
                    Country = curr_address.Country,
                    CountrySubDivisionCode = curr_address.State,
                    PostalCode = curr_address.ZipCode
                },

                Notes = "",
                DisplayName = curr_customer.LastName + ", " + curr_customer.FirstName,
                
                PrimaryPhone = new CustPhone
                {
                    FreeFormNumber = curr_customer.PhoneNumber
                },

                PrimaryEmailAddr = new CustEmailAddr
                {
                    Address = curr_customer.Email
                }
            };

            var CustResult = await CreateCustomerAsync(idToken, realmID, new_Customer);

            var ItemList = inv_convert.InvoicesLineList;
            int ItemSize = ItemList.Count;

            int IncomeAcct = 214;
            string IncomeName = "Sales of Product Income";

            int ExpenseAcct = 215;
            string ExpenseName = "Cost of Goods Sold";

            int AssetAcct = 213;
            string AssetName = "Inventory Asset";

            foreach (var item in ItemList)
            {
                var new_Item = new QB_Item
                {
                    Name = item.LineInventory.Name,
                    
                    IncomeAccountRef = new ItemIncomeAccountRef
                    {
                        value = IncomeAcct.ToString(),
                        name = IncomeName
                    },

                    ExpenseAccountRef = new ItemExpenseAccountRef
                    {
                        value = ExpenseAcct.ToString(),
                        name = ExpenseName
                    },

                    AssetAccountRef = new ItemAssetAccountRef
                    {
                        value = AssetAcct.ToString(),
                        name = AssetName
                    },

                    Type = "Inventory",
                    TrackQtyOnHand = false,
                    QtyOnHand = item.QuantitySold,
                    InvStartDate = inv_convert.InvoiceDate.ToString()
                };

                var ItemReturn = await CreateItemAsync(idToken, realmID, new_Item);
            }

            var new_Invoice = new QB_Invoice
            {
                Line = new List<LineObj>(),
                CustomerRef = new CustomerRefObj
                {
                    value = "2"
                }
            };

            return new_Invoice;
        }
    }
}