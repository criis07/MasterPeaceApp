using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Project4.Application.DTO.Products;
using Project4.Application.Endpoints.Users.Commands.Batchs;
using Project4.Domain.Entities;

namespace Project4.Application.Mapping
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, GetProductsDTO>()
                .ForMember(pr => pr.ProductId, lg => lg.MapFrom(src => src.ProductId))
                .ForMember(pr => pr.ProductCodeId, lg => lg.MapFrom(src => src.ProductCodeId))
                .ForMember(pr => pr.ImportDate, lg => lg.MapFrom(src => src.ImportDate))
                .ForMember(pr => pr.BatchId, lg => lg.MapFrom(src => src.BatchId))
                .ForMember(pr => pr.Available, lg => lg.MapFrom(src => src.Available));
        }
    }
}
