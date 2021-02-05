using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TavSystem.Entities;
using TavSystem.Models;

namespace TavSystem.Framework
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Category, >();
            //CreateMap<Customer, >();
            CreateMap<AccountingDocument, AccountingDocDto>(); 
            CreateMap<AccountingDocDto, AccountingDocument>(); 
            CreateMap<Invitem, InvitemDto>(); 
            CreateMap<InvitemDto, Invitem>(); 
            CreateMap<InvitemDetail, InvitemDetailDto>();
            CreateMap<InvitemDetailDto, InvitemDetail>(); 
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>();
        }
    }
}
