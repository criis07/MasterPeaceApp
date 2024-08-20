using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Project4.Application.DTO.Batchs;
using Project4.Domain.Entities;

namespace Project4.Application.Mapping
{
    public class BatchProfile : Profile
    {
        public BatchProfile()
        {
            CreateMap<Batch, BatchDTO>()
                .ForMember(bto => bto.BatchId, lg => lg.MapFrom(src => src.BatchId))
                .ForMember(bto => bto.ProfitMargin, lg => lg.MapFrom(src => src.ProfitMargin))
                .ForMember(bto => bto.TransportCost, lg => lg.MapFrom(src => src.TransportCost))
                .ForMember(bto => bto.ImportCost, lg => lg.MapFrom(src => src.ImportCost))
                .ForMember(bto => bto.GrossPrice, lg => lg.MapFrom(src => src.GrossPrice))
                .ForMember(bto => bto.Origin, lg => lg.MapFrom(src => src.Origin))
                .ForMember(bto => bto.ImportDate, lg => lg.MapFrom(src => src.ImportDate));
        }
    }
}
