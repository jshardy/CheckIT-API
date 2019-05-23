using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CheckIT.API.Models;
using checkit.api.Models.Quickbook_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CheckIT.API.Data
{
    public class QuickRepository
    {
        private readonly DataContext _context;
        private CustRepository _CustRepo;
        private InventoryRepository _InvRepo;
        static string baseURL = "https://sandbox-quickbooks.api.intuit.com/v3/company/";
        static string minorVersion = "37";


        public QuickRepository(DataContext context)
        {
            _context = context;
            _CustRepo = new CustRepository(context);
            _InvRepo = new InventoryRepository(context);
        }

        static async Task<JObject> CreateCustomerAsync(string access_token, QB_Customer Cust, string realmID)
        {
            string CustomerURL = realmID + "/customer?minorversion=4";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(access_token);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, CustomerURL);
            request.Content = new StringContent(JsonConvert.SerializeObject(Cust), null, "application/json");
            request.Headers.Host = "sandbox-quickbooks.api.intuit.com";

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = response.Content.ReadAsStringAsync().Result;

            System.Console.WriteLine("\n==========\nTemp: " + responseContent + "\n==========\n");
            System.Console.WriteLine("\n==========\nRequest: " + response.RequestMessage + "\n==========\n");
            System.Console.WriteLine("\n==========\nResponce: " + response + "\n==========\n");

            response.EnsureSuccessStatusCode();

            var responceObject = (JObject)JsonConvert.DeserializeObject(responseContent);

            var CustId = responceObject["Customer"]["Id"].Value<int>();

            return responceObject;
        }

        static async Task<JObject> GetCustomerAsync(string access_token, int CustIdQB, string realmID)
        {
            string CustomerURL = realmID + "/customer/" + CustIdQB + "?minorversion=4";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(access_token);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, CustomerURL);
            //request.Content = new StringContent(JsonConvert.SerializeObject(Cust), null, "application/json");
            //request.Headers.Host = "sandbox-quickbooks.api.intuit.com";

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = response.Content.ReadAsStringAsync().Result;
            
            System.Console.WriteLine("\n==========\nTemp: " + responseContent + "\n==========\n");
            System.Console.WriteLine("\n==========\nRequest: " + response.RequestMessage + "\n==========\n");
            System.Console.WriteLine("\n==========\nResponce: " + response + "\n==========\n");

            response.EnsureSuccessStatusCode();

            var responceObject = (JObject)JsonConvert.DeserializeObject(responseContent);

            return responceObject;
        }

        static async Task<JObject> CreateItemAsync(string access_token, QB_Item item, string realmID)
        {
            string ItemURL = realmID + "/item?minorversion=4";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(access_token);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ItemURL);
            request.Content = new StringContent(JsonConvert.SerializeObject(item), null, "application/json");
            request.Headers.Host = "sandbox-quickbooks.api.intuit.com";

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = response.Content.ReadAsStringAsync().Result;

            System.Console.WriteLine("\n==========\nTemp: " + responseContent + "\n==========\n");
            System.Console.WriteLine("\n==========\nRequest: " + response.RequestMessage + "\n==========\n");
            System.Console.WriteLine("\n==========\nResponce: " + response + "\n==========\n");

            response.EnsureSuccessStatusCode();

            var responceObject = (JObject)JsonConvert.DeserializeObject(responseContent);

            return responceObject;
        }

        static async Task<JObject> GetItemAsync(string access_token, int ItemIdQB, string realmID)
        {
            string CustomerURL = realmID + "/item/" + ItemIdQB + "?minorversion=4";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(access_token);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, CustomerURL);
            //request.Content = new StringContent(JsonConvert.SerializeObject(Cust), null, "application/json");
            request.Headers.Host = "sandbox-quickbooks.api.intuit.com";

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = response.Content.ReadAsStringAsync().Result;

            System.Console.WriteLine("\n==========\nTemp: " + responseContent + "\n==========\n");
            System.Console.WriteLine("\n==========\nRequest: " + response.RequestMessage + "\n==========\n");
            System.Console.WriteLine("\n==========\nResponce: " + response + "\n==========\n");

            response.EnsureSuccessStatusCode();

            var responceObject = (JObject)JsonConvert.DeserializeObject(responseContent);

            return responceObject;
        }

        static async Task<JObject> CreateInvoiceAsync(string access_token, QB_Invoice inv, string realmID)
        {
            string ItemURL = realmID + "/invoice?minorversion=4";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(access_token);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ItemURL);
            request.Content = new StringContent(JsonConvert.SerializeObject(inv), null, "application/json");
            request.Headers.Host = "sandbox-quickbooks.api.intuit.com";

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = response.Content.ReadAsStringAsync().Result;

            System.Console.WriteLine("\n==========\nTemp: " + responseContent + "\n==========\n");
            System.Console.WriteLine("\n==========\nRequest: " + response.RequestMessage + "\n==========\n");
            System.Console.WriteLine("\n==========\nResponce: " + response + "\n==========\n");

            response.EnsureSuccessStatusCode();

            var responceObject = (JObject)JsonConvert.DeserializeObject(responseContent);

            return responceObject;
        }

        public async Task<JObject> SendInvoice(Invoice inv_convert, string access_token, string realmID)
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

            JObject CustResult;
            if(inv_convert.InvoiceCust.QB_Id == -1)
            {
                CustResult = await CreateCustomerAsync(access_token, new_Customer, realmID);
                Customer exist = await _context.Customers.FirstOrDefaultAsync(x => x.Id == inv_convert.InvoiceCust.Id);
                exist.QB_Id = CustResult["Customer"]["Id"].Value<int>();
                _context.Customers.Update(exist);
                await _context.SaveChangesAsync();
            }
            else
            {
                CustResult = await GetCustomerAsync(access_token, inv_convert.InvoiceCust.QB_Id, realmID);
            }

            var ItemList = inv_convert.InvoicesLineList;
            int ItemSize = ItemList.Count;

            int IncomeAcct = 487;
            string IncomeName = "Sales";

            int ExpenseAcct = 517;
            string ExpenseName = "Cost of Goods Sold";

            int AssetAcct = 519;
            string AssetName = "Inventory";

            var new_Invoice = new QB_Invoice()
            {
                Line = new List<LineObj>()
            };

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
                    TrackQtyOnHand = true,
                    QtyOnHand = item.QuantitySold,
                    InvStartDate = DateTime.Now.ToString("yyyy-MM-dd")
                };

                JObject ItemReturn;
                if(item.LineInventory.QB_Id == -1)
                {
                    ItemReturn = await CreateItemAsync(access_token, new_Item, realmID);
                    Inventory exist = await _context.Inventories.FirstOrDefaultAsync(x => x.Id == item.LineInventory.Id);
                    exist.QB_Id = ItemReturn["Item"]["Id"].Value<int>();
                    _context.Inventories.Update(exist);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ItemReturn = await GetItemAsync(access_token, item.LineInventory.QB_Id, realmID);
                }

                var new_line = new LineObj()
                {
                    Amount = (float)item.Price,
                    SalesItemLineDetail = new SalesItemLineDetailObj()
                    {
                        ItemRef = new ItemRefObj()
                        {
                            value = ItemReturn["Item"]["Id"].Value<int>().ToString(),
                            name = ItemReturn["Item"]["Name"].Value<string>().ToString()
                        },
                        Qty = item.QuantitySold
                    }

                };
                new_Invoice.Line.Add(new_line);
            }

            new_Invoice.CustomerRef = new CustomerRefObj()
            {
                value = CustResult["Customer"]["Id"].Value<int>().ToString()
            };

            var InvResult = CreateInvoiceAsync(access_token, new_Invoice, realmID).Result;

            return InvResult;
        }
    }
}