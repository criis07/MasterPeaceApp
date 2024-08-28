using AutoMapper;
using Project4.Application.DTO;
using Project4.Domain.Entities;

namespace Project4.Application.Mapping;

public class MarcasAutosProfile : Profile
{
    public MarcasAutosProfile()
    {
        CreateMap<MarcasAutos, MarcasAutosDTO>()
            .ForMember(MA => MA.Id, DT => DT.MapFrom(src => src.Id))
            .ForMember(MA => MA.Name, DT => DT.MapFrom(src => src.Name));
    }
}
