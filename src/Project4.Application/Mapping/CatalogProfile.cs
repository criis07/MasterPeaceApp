using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Endpoints.Users.Commands.Catalogs;
using Project4.Domain.Entities;

namespace Project4.Application.Mapping
{
    public class CatalogProfile : Profile
    {
        public CatalogProfile()
        {
            CreateMap<CatalogCommand, CreateCatalogDTO>()
                .ForMember(cdt => cdt.ProductCode, lg => lg.MapFrom(src => src.ProductCode))
                .ForMember(cdt => cdt.CatalogDescription, lg => lg.MapFrom(src => src.CatalogDescription));

            CreateMap<Catalog, CreateCatalogDTO>()
                .ForMember(cdt => cdt.CatalogId, lg => lg.MapFrom(src => src.CatalogId))
                .ForMember(cdt => cdt.ProductCode, lg => lg.MapFrom(src => src.ProductCode))
                .ForMember(cdt => cdt.CatalogDescription, lg => lg.MapFrom(src => src.CatalogDescription));

            CreateMap<UpdateCatalogCommand, UpdateCatalogDTO>()
                .ForMember(ctu => ctu.CatalogId, lg => lg.MapFrom(src => src.CatalogId))
                .ForMember(ctu => ctu.ProductCode, lg => lg.MapFrom(src => src.ProductCode))
                .ForMember(ctu => ctu.CatalogDescription, lg => lg.MapFrom(src => src.CatalogDescription));
        }
    }
}
