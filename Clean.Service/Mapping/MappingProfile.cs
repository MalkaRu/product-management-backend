using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;


namespace Clean.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
                .ForMember(dest => dest.Sales, opt => opt.Ignore());
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0));
            CreateMap<Sales, SaleDto>();
            CreateMap<SaleDto, Sales>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0));
            // מיפוי רגיל ל-Seller (ללא Password) - שנה את זה
            CreateMap<Seller, SellerDto>();
            CreateMap<SellerDto, Seller>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != 0))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Sales, opt => opt.Ignore());
                        
            // מיפוי לאימות (עם Password)
            CreateMap<Seller, SellerAuthDto>().ReverseMap();


        }
    }
}
