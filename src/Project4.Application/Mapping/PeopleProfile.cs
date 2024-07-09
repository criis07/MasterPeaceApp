using AutoMapper;
using Project4.Application.DTO;
using Project4.Application.Endpoints.People;
using Project4.Application.Endpoints.People.Commands;
using Project4.Domain.Entities;

namespace Project4.Application.Mapping;

public class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<Person, PersonViewModel>()
            .ReverseMap();
        CreateMap<AddPersonCommand, Person>()
            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

        CreateMap<MarcasAutos, MarcasAutosDTO>()
            .ForMember(MA => MA.Id, DT => DT.MapFrom(src => src.Id))
            .ForMember(MA => MA.Name, DT => DT.MapFrom(src => src.Name))
            .ForMember(MA => MA.CreatedBy, DT => DT.MapFrom(src => src.CreatedBy))
            .ForMember(MA => MA.CreatedOn, DT => DT.MapFrom(src => src.CreatedOn))
            .ForMember(MA => MA.ModifiedOn, DT => DT.MapFrom(src => src.ModifiedOn))
            .ForMember(MA => MA.ModifiedBy, DT => DT.MapFrom(src => src.ModifiedBy));

    }
}
