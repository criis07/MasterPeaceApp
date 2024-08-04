using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO.Users;
using Project4.Application.Interfaces.Persistence.DataServices.User;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, EndpointResult<RegistrationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RegisterCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<EndpointResult<RegistrationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var logRequest = _mapper.Map<RegisterUserDTO>(request);
            var logMethod = await _userService.RegisterUserAsync(logRequest);

            return new EndpointResult<RegistrationResponse>(logMethod);
        }
    }
}
