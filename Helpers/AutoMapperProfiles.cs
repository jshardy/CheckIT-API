using System.Collections.Generic;
using AutoMapper;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using CheckIT.API.Data;

namespace CheckIT.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerData>()
                .ForMember(dest => dest.CustomerInvoiceList,
                           opt => opt.Ignore());
            CreateMap<CustomerData, Customer>()
                .ForMember(dest => dest.CustAddress,
                           opt => opt.Ignore())
                .ForMember(dest => dest.CustomerInvoiceList,
                           opt => opt.Ignore());
            
            CreateMap<Address, AddressData>()
                .ForMember(dest => dest.AddressCustID,
                           opt => opt.MapFrom(src => src.AddressCust.Id));
            CreateMap<AddressData, Address>()
                .ForMember(dest => dest.AddressCustID,
                           opt => opt.Ignore())
                .ForMember(dest => dest.Id,
                           opt => opt.Ignore());

            CreateMap<Invoice, InvoiceData>();
            CreateMap<Alert, AlertData>();
            CreateMap<Inventory, InventoryData>();
            CreateMap<Invoice, InvoiceData>();
            CreateMap<LineItem, LineItemData>();
        }
    }
}