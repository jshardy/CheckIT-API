using Microsoft.AspNetCore.Http;
using CheckIT.API.Data;
using CheckIT.API.Models;
using System.Collections.Generic;

namespace CheckIT.API.Helpers
{
    //Adds helpers for displaying error messages.
    //check startup.cs
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message) 
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static List<int> toIntList(this List<Invoice> InvoiceList)
        {
            List<int> IntListReturn = new List<int>() {};

            if (InvoiceList.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in InvoiceList)
                {
                    var Id = item.Id;
                    IntListReturn.Add(Id);
                }
            
                return IntListReturn;
            }
        }

        public static ICollection<Invoice> toInvoiceList(this List<int> intList, 
                                                         InvoiceRepository _InvRepo)
        {
            List<Invoice> InvoiceListReturn = new List<Invoice>() {};

            foreach (var item in intList)
            {
                var InvoiceToAdd = _InvRepo.GetOneInvoice(item).Result;
                InvoiceListReturn.Add(InvoiceToAdd);
            }

            return InvoiceListReturn;
        }
    }
}