using System.Reflection.Emit;
using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Logging;
using Project4.Application.DTO.Users;
using Project4.Application.Endpoints.APIs.Commands.AuthUsers;

namespace Project4.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginCommand, LoginDTO>()
                .ForMember(ldt => ldt.Email, lg => lg.MapFrom(src => src.Email))
                .ForMember(ldt => ldt.Password, lg => lg.MapFrom(src => src.Password));

            CreateMap<RegisterCommand, RegisterUserDTO>()
                .ForMember(rdt => rdt.Email, lg => lg.MapFrom(src => src.Email))
                .ForMember(rdt => rdt.Password, lg => lg.MapFrom(src => src.Password))
                .ForMember(rdt => rdt.Name, lg => lg.MapFrom(src => src.Name))
                .ForMember(rdt => rdt.LastName, lg => lg.MapFrom(src => src.LastName))
                .ForMember(rdt => rdt.ConfirmPassword, lg => lg.MapFrom(src => src.ConfirmPassword));
        }
    }
}
