using AutoMapper;
using CheckIT.API.Dtos;
using CheckIT.API.Models;

namespace CheckIT.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerData>();
            CreateMap<Invoice, InvoiceData>();
            CreateMap<Alert, AlertData>();
            CreateMap<Address, AddressData>();
            CreateMap<Inventory, InventoryData>();
            CreateMap<Invoice, InvoiceData>();  
            CreateMap<LineItem, LineItemData>();
        }
    }
}