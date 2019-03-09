using System.Collections.Generic;
using AutoMapper;
using CheckIT.API.Dtos;
using CheckIT.API.Models;
using CheckIT.API.Data;

namespace CheckIT.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        private readonly AddressRepository _AddRepo;
        private readonly InvoiceRepository _InvRepo;

        public AutoMapperProfiles()
        { 
            
        }

        public AutoMapperProfiles(AddressRepository AddRepo,
                                  InvoiceRepository InvRepo)
        {
            _AddRepo = AddRepo;
            _InvRepo = InvRepo;

            CreateMap<Customer, CustomerData>()
                .ForMember(dest => dest.AddressID,
                            opt => opt.MapFrom(src => src.CustAddress))
                .ForMember(dest => dest.CustomerInvoiceList,
                            opt => opt.MapFrom(src => src.CustomerInvoiceList.toIntList()));
            CreateMap<CustomerData, Customer>()
                .ForMember(dest => dest.CustAddress, 
                           opt => opt.MapFrom(src => _AddRepo.GetAddress(src.AddressID)))
                .ForMember(dest => dest.CustomerInvoiceList,
                           opt => opt.MapFrom(src => src.CustomerInvoiceList.toInvoiceList(_InvRepo)));
            CreateMap<Invoice, InvoiceData>();
            CreateMap<Alert, AlertData>();
            CreateMap<Address, AddressData>();
            CreateMap<Inventory, InventoryData>();
            CreateMap<Invoice, InvoiceData>();
            CreateMap<LineItem, LineItemData>();
        }
    }
}